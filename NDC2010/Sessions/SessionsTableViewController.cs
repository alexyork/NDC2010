using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Logic.Presenters;
using NDC2010.Logic;

namespace NDC2010
{
	[Register("SessionsTableViewController")]
	public partial class SessionsTableViewController : NDC2010TableViewController
    {
		private static NSString CELL_ID = new NSString("SessionsTableCell");
		
		public int Day { get; set; }
		public SessionsPresenter Presenter { get; set; }
		
		public SessionsTableViewController() : base(UITableViewStyle.Grouped)
		{
			Presenter = new SessionsPresenter();
			Presenter.Sessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
		}
        
		class TableSource : UITableViewSource
		{
			private SessionsTableViewController _tvc;
			private SessionTableViewController _sessionTableViewController;
		
			public TableSource(SessionsTableViewController tvc)
			{
				_tvc = tvc;
			}

			public override int NumberOfSections(UITableView tableView)
			{
				return _tvc.Presenter.GetNumberOfDailyTimeslots();
			}

			public override int RowsInSection(UITableView tableView, int section)
			{
				return _tvc.Presenter.GetSessionsForSection(section).Count();
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				return _tvc.Presenter.GetTimeForSection(section);
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _tvc.DequeueOrCreateTableCell(tableView, CELL_ID, UITableViewCellStyle.Subtitle);
				
				var session = _tvc.Presenter.GetSessionsForSection(indexPath.Section).ElementAt(indexPath.Row);
				cell.TextLabel.Text = session.Title;
				cell.DetailTextLabel.Text = session.Speakers[0].Name;
				
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				if (_sessionTableViewController == null)
					_sessionTableViewController = new SessionTableViewController();
				
				var session = _tvc.Presenter.GetSessionsForSection(indexPath.Section).ElementAt(indexPath.Row);
				_sessionTableViewController.BindSession(session);
				
				_tvc.NavigationController.PushViewController(_sessionTableViewController, true);
				_tvc.SelectedRow = indexPath;
			}
		}
		
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			
			Title = "Sessions, Day " + Day;
			Presenter.Day = Day;
			TableView.ReloadData();
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			var frame = new RectangleF(0, 0, View.Bounds.Width, 367);
			TableView = new UITableView(frame, Style)
			{
				Source = new TableSource(this),
				BackgroundColor = UIColor.Clear
			};
			
			View.AddSubview(TableView);
		}
	}
}