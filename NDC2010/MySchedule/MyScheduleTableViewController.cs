using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Logic;
using NDC2010.Logic.Presenters;

namespace NDC2010
{
	[Register("MyScheduleTableViewController")]
	public partial class MyScheduleTableViewController : NDC2010TableViewController
    {
		private static NSString CELL_ID = new NSString("MyScheduleCellID");
	
		protected MySchedulePresenter Presenter { get; set; }
		protected List<Session> SelectedSessions { get; set; }
		
		public MyScheduleTableViewController() : base(UITableViewStyle.Grouped)
		{
			var allSessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
			Presenter = new MySchedulePresenter(allSessions);
		}
        
		class TableSource : UITableViewSource
		{
			MyScheduleTableViewController _tvc;
		
			public TableSource(MyScheduleTableViewController tvc)
			{
				_tvc = tvc;
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 3;
			}
			
			public override int RowsInSection(UITableView tableView, int section)
			{
				int day = section + 1;
				return _tvc.SelectedSessions.Where(s => s.Day == day).Count();
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _tvc.DequeueOrCreateTableCell(tableView, CELL_ID, UITableViewCellStyle.Subtitle);
				
				int day = indexPath.Section + 1;
				var session = _tvc.SelectedSessions.Where(s => s.Day == day).ElementAt(indexPath.Row);
				
				cell.TextLabel.Text = session.Title;
				cell.DetailTextLabel.Text = session.GetTimeTrackSpeakerInfo();
				
				return cell;
			}
		
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				int day = indexPath.Section + 1;
				var session = _tvc.SelectedSessions.Where(s => s.Day == day).ElementAt(indexPath.Row);
				
				_tvc.PushSessionViewController(session, indexPath);
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				int day = section + 1;
				return _tvc.Presenter.GetHeadingTextForDay(day);
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Console.WriteLine("ViewDidLoad");
			
			NavigationItem.Title = Presenter.GetTitle();
			
			var frame = new RectangleF(0, 0, View.Bounds.Width, 367);
			TableView = new UITableView(frame, Style)
			{
				Source = new TableSource(this),
				BackgroundColor = UIColor.Clear
			};
			View.AddSubview(TableView);
		}
		
		public override void ViewWillAppear(bool animated)
		{
			Console.WriteLine("ViewWillAppear");
			SelectedSessions = Presenter.GetSessions();
			TableView.ReloadData();
		}
	}
}