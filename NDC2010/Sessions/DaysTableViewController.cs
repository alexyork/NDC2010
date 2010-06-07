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
			
			public override UIView GetViewForHeader(UITableView tableView, int section)
			{
				var headingText = _tvc.Presenter.GetTitleForSection();
				return _tvc.GetViewForHeader(section, headingText);
			}
			
			public override float GetHeightForHeader(UITableView tableView, int section)
			{
				return 44f;
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _tvc.DequeueOrCreateTableCell(tableView, CELL_ID, UITableViewCellStyle.Subtitle);
				
				cell.TextLabel.Text = "Day " + GetDay(indexPath);
				cell.DetailTextLabel.Text = _tvc.Presenter.GetTextForDay(indexPath.Row);
		
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				int day = GetDay(indexPath);
				
				var sessionsTableViewController = new SessionsTableViewController(day);
				_tvc.NavigationController.PushViewController(sessionsTableViewController, true);
				
				_tvc.SelectedRow = indexPath;
			}
			
			private int GetDay(NSIndexPath indexPath)
			{
				return indexPath.Row + 1;
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