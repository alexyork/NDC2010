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
		private static NSString CELL_WITH_DETAIL_ID = new NSString("SessionTableCell_WithDetail");
		
		protected SessionPresenter Presenter;
	
		public SessionTableViewController(Session session) : base(UITableViewStyle.Grouped)
		{
			Presenter = new SessionPresenter();
			Presenter.Session = session;
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
				return (section == 0) ? 2 : 1;
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 2;
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				return (section == 0)
					? _tvc.Presenter.GetHeadingTextForSessionInfo()
					: _tvc.Presenter.GetHeadingTextForSessionDescription();
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell;
				
				if (CellHasDetailsLabel(indexPath))
				{
					cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_WITH_DETAIL_ID, UITableViewCellStyle.Subtitle);
					cell.TextLabel.Font = NDC2010Fonts.SubtitleFont;
					cell.TextLabel.Text = _tvc.Presenter.GetTextForSpeakers();
					cell.DetailTextLabel.Text = _tvc.Presenter.GetTextForTimeAndPlace();
				}
				else
				{
					cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_ID);
					cell.TextLabel.Text = GetCellText(indexPath);
				}
				
				return cell;
			}
			
			public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return CellHasDetailsLabel(indexPath)
					? 44f
					: GetCellHeightForRow(GetCellText(indexPath), tableView, indexPath);
			}
			
			private bool CellHasDetailsLabel(NSIndexPath indexPath)
			{
				return (indexPath.Section == 0 && indexPath.Row == 1);
			}
			
			private string GetCellText(NSIndexPath indexPath)
			{
				if (indexPath.Section == 0 && indexPath.Row == 0)
					return _tvc.Presenter.Session.Title;
				if (indexPath.Section == 1 && indexPath.Row == 0)
					return _tvc.Presenter.Session.Description;
				return "";
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			Title = Presenter.GetTitle();
			View.BackgroundColor = UIColor.Clear;
			TableView.Source = new TableSource(this);
		}
	}
}