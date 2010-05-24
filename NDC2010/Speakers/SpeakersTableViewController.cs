using System;
using System.Collections.Generic;
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
		
		protected List<Speaker> Speakers { get; set; }
        
		public SpeakersTableViewController() : base(UITableViewStyle.Plain)
		{
			var allSessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
			Presenter = new SpeakersPresenter(allSessions);
		}
		
		class TableSource : UITableViewSource
		{
			private SpeakersTableViewController _tvc;
		
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
				var speaker = _tvc.Presenter.GetAllSpeakers().ElementAt(indexPath.Row);
				
				var speakerTableViewController = new SpeakerTableViewController(speaker);
				_tvc.NavigationController.PushViewController(speakerTableViewController, true);
				
				_tvc.SelectedRow = indexPath;
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			Title = Presenter.GetTitle();
			Speakers = Presenter.GetAllSpeakers();
			
			var frame = new RectangleF(0, 0, View.Bounds.Width, 367);
			TableView = new UITableView(frame, Style)
			{
				Source = new TableSource(this),
				BackgroundColor = UIColor.Clear,
				SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine,
				SeparatorColor = NDC2010Colors.LightYellow
			};
			View.AddSubview(TableView);
		}
	}
}