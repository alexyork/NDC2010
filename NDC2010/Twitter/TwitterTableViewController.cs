using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010
{
	[Register("TwitterTableViewController")]
	public partial class TwitterTableViewController : UITableViewController
    {
		protected static NSString CELL_ID = new NSString("TwitterTableCell");
		
		protected List<Tweet> Tweets = new List<Tweet>();
		protected Dictionary<int, TweetCellController> CellControllers = new Dictionary<int, TweetCellController>();
		
		private UIActivityIndicatorView _activityView;
		
		class TableSource : UITableViewSource
		{
			private TwitterTableViewController _tvc;
			private Dictionary<string, UIImage> _images;
			
			private UIFont _cellFont;
			private SizeF _baseLabelSize;
			
			private const int PADDING = 5;
			private const int FULL_WIDTH = 320;
		
			public TableSource(TwitterTableViewController tvc)
			{
				_tvc = tvc;
				_images = new Dictionary<string, UIImage>();
				
				_cellFont = UIFont.FromName("Helvetica", 14.0f);
				_baseLabelSize = new SizeF(258, 1000.0f);
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				return _tvc.Tweets.Count();
			}
			
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				Tweet tweet = _tvc.Tweets[indexPath.Row];
				TweetCellController cellController = null;
				UITableViewCell cell = tableView.DequeueReusableCell(CELL_ID);
		
				if (cell == null)
				{
					cellController = new TweetCellController();
					NSBundle.MainBundle.LoadNib("TweetCellController", cellController, null);
					
					cell = cellController.Cell;
					cell.Tag = Environment.TickCount + indexPath.Row;
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;
					
					GetImage(cellController, tweet);
					
					_tvc.CellControllers.Add(cell.Tag, cellController);
				}
				else
				{
					cellController = _tvc.CellControllers[cell.Tag];
				}
				
				if (tweet != null)
				{
					// Size and position the text label
					cellController.TextLabel.Text = tweet.Content;
					cellController.NameLabel.Text = tweet.AuthorName;
					cellController.DateLabel.Text = FriendlyDateTime.Get(tweet.Timestamp, DateTime.Now);
					
					cellController.TextLabel.Frame = new RectangleF(58, 23, 258 /* 257? */, tweet.LabelSize.Height);
				}
				
				return cell;
			}
			
			#region Twitter Image Loading
			
			private void GetImage(TweetCellController controller, Tweet tweet)
			{
				controller.ImageView.Alpha = 0.0f;
			    if (!string.IsNullOrEmpty(tweet.AuthorImageUrl))
			    {
			        if (_images.ContainsKey(tweet.AuthorImageUrl))
			        {
			            UIImage imageThumbnail = _images[tweet.AuthorImageUrl];
			            controller.ImageView.Image = imageThumbnail;
			            controller.ImageView.Alpha = 1.0f;
			        }
			        else
			        {
			            controller.AuthorImageUrl = tweet.AuthorImageUrl;
			            ThreadPool.QueueUserWorkItem(RequestImage, controller);
			        }
			    }
			}
			
			private void RequestImage(object state)
			{
				TweetCellController controller = state as TweetCellController;
			    if (controller != null)
			    {
			        NSUrl imageUrl = NSUrl.FromString(controller.AuthorImageUrl);
			        NSData imageData = NSData.FromUrl(imageUrl);
			        controller.ImageView.Image = UIImage.LoadFromData(imageData);
			
					if (!_images.ContainsKey(controller.AuthorImageUrl))
			        		_images.Add(controller.AuthorImageUrl, controller.ImageView.Image);
					
			        InvokeOnMainThread(delegate { RefreshImage(controller); });
			    }
			}
			
			private void RefreshImage(TweetCellController controller)
			{
				UIView.BeginAnimations("imageThumbnailTransitionIn");
			    UIView.SetAnimationDuration(0.5f);
			    controller.ImageView.Alpha = 1.0f;
			    UIView.CommitAnimations();
			}
			
			#endregion
			
			public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				Tweet tweet = _tvc.Tweets[indexPath.Row];
				
				// Calculate the height of the label, but force the width
				SizeF labelSize = tableView.StringSize(tweet.Content, _cellFont, _baseLabelSize, UILineBreakMode.TailTruncation);
				labelSize.Width = _baseLabelSize.Width;
				
				// Calculate the size of the cell
				float cellHeight = PADDING + 18 + labelSize.Height + PADDING;
				if (cellHeight < 76f)
					cellHeight = 76f;
				SizeF cellSize = new SizeF(FULL_WIDTH, cellHeight);
				
				tweet.LabelSize = labelSize;
            		tweet.CellSize = cellSize;
				
				return tweet.CellSize.Height;
			}
		}
		
		public override void ViewDidLoad()
		{
			TableView.Source = new TableSource(this);
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			// TODO: use a static color?
			TableView.SeparatorColor = new UIColor(255/255f, 245/255f, 188/255f, 1.0f);
			
			// TODO: move to logic
			Title = "Twitter";
			View.BackgroundColor = UIColor.Clear;
			
			SetupRefreshButton();
			FetchAndBindTweetsAsync();
		}
		
		private void FetchAndBindTweetsAsync()
		{
			BlockUI();
			
			if (!Reachability.IsHostReachable("search.twitter.com"))
			{
				ShowAlert("No Internet Access", "Can't get the latest #NDC2010 Tweets without an Internet connection", "OK");
				UnblockUI();
			}
			else
			{
				Thread thread = new Thread(FetchAndBindTweets);
				thread.Start();
			}
		}
		
		private void ShowAlert(string title, string message, string cancelButton)
		{
			using (var alert = new UIAlertView(title, message, null, cancelButton, null))
			{
				alert.Show();
			}
		}
		
		private void BlockUI()
		{
			TableView.UserInteractionEnabled = false;
			NavigationItem.RightBarButtonItem.Enabled = false;
			
			if (_activityView == null)
			{
				_activityView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
		    		_activityView.Frame = new RectangleF(140, 140, 30, 30);
				View.AddSubview(_activityView);
			}
			_activityView.StartAnimating();
		}
		
		private void FetchAndBindTweets()
		{
			using (var networkActivity = new NetworkActivity())
			{
				using (var threadAutoRelease = new NSAutoreleasePool())
				{
					var twitterXml = XDocument.Load("http://search.twitter.com/search.atom?q=NDC2010");
					BindTweetsToTable(twitterXml);
				}
			}
			
			UnblockUI();
		}
		
		private void UnblockUI()
		{
			// Unblock the UI
			TableView.UserInteractionEnabled = true;
			NavigationItem.RightBarButtonItem.Enabled = true;
			_activityView.StopAnimating();
		}
		
		private void SetupRefreshButton()
		{
			var refreshButton  = new UIBarButtonItem(UIBarButtonSystemItem.Refresh);
			refreshButton.Clicked += delegate {
				Tweets = new List<Tweet>();
				TableView.ReloadData();
				FetchAndBindTweetsAsync();
			};
			NavigationItem.RightBarButtonItem = refreshButton;
		}
		
		private void BindTweetsToTable(XDocument twitterXml)
		{
			Tweets = (from tweetXml in twitterXml.Descendants(TweetConverter.NS + "entry")
			          select TweetConverter.FromXml(tweetXml)).ToList();
			
			InvokeOnMainThread(() => TableView.ReloadData());
			InvokeOnMainThread(() => TableView.Hidden = false);
			
			Console.WriteLine("BindTweetsToTable: " + Tweets.Count());
		}
	}
}