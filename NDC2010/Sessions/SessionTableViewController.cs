using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010
{
	[Register("SessionTableViewController")]
	public partial class SessionTableViewController : UITableViewController
    {
		private static NSString CELL_ID = new NSString("SessionTableCell");
		
		protected SessionPresenter Presenter;
	
		public SessionTableViewController() : base(UITableViewStyle.Grouped)
		{
			Presenter = new SessionPresenter();
		}
		
		public void BindSession(Session session)
		{
			Presenter.Session = session;
		}
		
		public override void ViewWillAppear(bool animated)
		{
			TableView.ReloadData();
		}
        
		class TableSource : NDC2010DetailsTableViewSource
		{
			private SessionTableViewController _tvc;
		
			public TableSource(SessionTableViewController tvc)
			{
				_tvc = tvc;
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				return 1;
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 2;
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				return _tvc.Presenter.GetSectionHeadingText(section);
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_ID);
		
				cell.TextLabel.Text = _tvc.Presenter.GetCellTextForSection(indexPath.Section);
		
				return cell;
			}
		
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				Console.WriteLine("NDC2010.Sessions: Row selected {0}", indexPath.Row);
			}
			
			public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return GetCellHeightForRow(_tvc.Presenter.GetCellTextForSection(indexPath.Section),
                                           tableView,
				                           indexPath);
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			Title = "Session";
			View.BackgroundColor = UIColor.Clear;
			TableView.Source = new TableSource(this);
		}
	}
}