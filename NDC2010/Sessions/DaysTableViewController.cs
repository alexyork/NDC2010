using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Logic.Presenters;

namespace NDC2010
{
	[Register("DaysTableViewController")]
	public partial class DaysTableViewController : NDC2010TableViewController
    {
		private static NSString CELL_ID = new NSString("DaysTableCell");
		
		protected DaysPresenter Presenter;
	
		public DaysTableViewController() : base(UITableViewStyle.Grouped)
		{
			Presenter = new DaysPresenter();
		}
        
		class TableSource : UITableViewSource
		{
			private DaysTableViewController _tvc;
		
			public TableSource(DaysTableViewController tvc)
			{
				_tvc = tvc;
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				return _tvc.Presenter.GetNumberOfDays();
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 1;
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				return _tvc.Presenter.GetTitleForSection();
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _tvc.DequeueOrCreateTableCell(tableView, CELL_ID, UITableViewCellStyle.Subtitle);
				
				// TODO: cleanup
				cell.TextLabel.Text = "Day " + (indexPath.Row + 1);
				cell.DetailTextLabel.Text = _tvc.Presenter.GetTextForDay(indexPath.Row);
		
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				var sessionsTableViewController = new SessionsTableViewController();
				
				// TODO: cleanup
				sessionsTableViewController.Day = (indexPath.Row + 1);
				
				_tvc.NavigationController.PushViewController(sessionsTableViewController, true);
				_tvc.SelectedRow = indexPath;
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			NavigationItem.Title = Presenter.GetTitle();
			
			TableView = new UITableView(View.Bounds, Style)
			{
				Source = new TableSource(this),
				BackgroundColor = UIColor.Clear
			};
			View.AddSubview(TableView);
		}
	}
}