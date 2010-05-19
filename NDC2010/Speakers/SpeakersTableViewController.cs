using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Logic.Presenters;
using NDC2010.Model;

namespace NDC2010
{
	[Register("SpeakersTableViewController")]
	public partial class SpeakersTableViewController : NDC2010TableViewController
    {
		private static NSString CELL_ID = new NSString("SpeakersTableCell");
		
		public SpeakersPresenter Presenter { get; set; }
		
		protected Speaker[] Speakers { get; set; }
        
		public SpeakersTableViewController() : base(UITableViewStyle.Plain)
		{
			Presenter = new SpeakersPresenter();
			Presenter.Sessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
		}
		
		class TableSource : UITableViewSource
		{
			private SpeakersTableViewController _tvc;
			private SpeakerTableViewController _speakerTableViewController;
		
			public TableSource(SpeakersTableViewController tvc)
			{
				_tvc = tvc;
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				return _tvc.Speakers.Count();
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _tvc.DequeueOrCreateTableCell(tableView, CELL_ID);
				cell.BackgroundColor = UIColor.Clear;
				
				cell.TextLabel.Text = _tvc.Speakers.ElementAt(indexPath.Row).Name;
		
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				if (_speakerTableViewController == null)
					_speakerTableViewController = new SpeakerTableViewController();
				
				var speaker = _tvc.Presenter.GetAllSpeakers().ElementAt(indexPath.Row);
				_speakerTableViewController.BindSpeaker(speaker);
				
				_tvc.NavigationController.PushViewController(_speakerTableViewController, true);
				_tvc.SelectedRow = indexPath;
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// TODO: move to logic
			Title = "Speakers";
			Speakers = Presenter.GetAllSpeakers();
			
			var frame = new RectangleF(0, 0, View.Bounds.Width, 367);
			TableView = new UITableView(frame, Style)
			{
				Source = new TableSource(this),
				BackgroundColor = UIColor.Clear,
				SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine,
				// TODO: use a static color?
				SeparatorColor = new UIColor(255/255f, 245/255f, 188/255f, 1.0f)
			};
			View.AddSubview(TableView);
		}
	}
}