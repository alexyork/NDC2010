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
	[Register("SpeakerTableViewController")]
	public partial class SpeakerTableViewController : NDC2010TableViewController
    {
		private static NSString CELL_ID = new NSString("SpeakerTableCell");
		private static NSString CELL_WITH_DETAIL_ID = new NSString("SpeakerTableCell_WithDetail");
		
		protected SpeakerPresenter Presenter { get; set; }
	
		public SpeakerTableViewController(Speaker speaker) : base(UITableViewStyle.Grouped)
		{
			Presenter = new SpeakerPresenter();
			Presenter.Speaker = speaker;
			Presenter.Sessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
		}
        
		class TableSource : NDC2010DetailsTableViewSource
		{
			private SpeakerTableViewController _tvc;
			private List<Session> _sessions;
		
			public TableSource(SpeakerTableViewController tvc)
			{
				_tvc = tvc;
				_sessions = _tvc.Presenter.GetSessions();
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				if (section == 1)
					return _sessions.Count();
				return 2;
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 2;
			}
			
			private string TitleForHeader(int section)
			{
				return (section == 0)
					? _tvc.Presenter.GetHeadingTextForName()
					: _tvc.Presenter.GetHeadingTextForSessions();
			}
			
			public override UIView GetViewForHeader(UITableView tableView, int section)
			{
				var headingText = TitleForHeader(section);
				return _tvc.GetViewForHeader(section, headingText);
			}
			
			public override float GetHeightForHeader(UITableView tableView, int section)
			{
				return 44f;
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell;
				
				if (CellHasDetailsLabel(indexPath))
				{
					cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_WITH_DETAIL_ID, UITableViewCellStyle.Subtitle, true);
					cell.TextLabel.Text = _sessions.ElementAt(indexPath.Row).Title;
					cell.DetailTextLabel.Text = _sessions.ElementAt(indexPath.Row).GetDayTimeTrackInfo();
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
					: GetCellHeightForRow(GetCellText(indexPath), tableView,indexPath);
			}
			
			private string GetCellText(NSIndexPath indexPath)
			{
				if (indexPath.Section == 0 && indexPath.Row == 0)
					return _tvc.Presenter.Speaker.Name;
				if (indexPath.Section == 0 && indexPath.Row == 1)
					return _tvc.Presenter.Speaker.Info;
				
				return _sessions.ElementAt(indexPath.Row).Title;
			}
			
			private bool CellHasDetailsLabel(NSIndexPath indexPath)
			{
				return (indexPath.Section == 1);
			}
			
			protected override UIFont GetFont(NSIndexPath indexPath)
			{
				if (indexPath.Section == 0 && indexPath.Row == 1)
					return NDC2010Fonts.CellFont;
				return NDC2010Fonts.TitleFont;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				// TODO: is this the best way to disable user interaction of the non-clickable cells?
				// or should this be set when the cells are created?
				if (indexPath.Section == 0) return;
				
				var session = _sessions.ElementAt(indexPath.Row);
				
				_tvc.PushSessionViewController(session, indexPath);
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			Title = Presenter.GetTitle();
			View.BackgroundColor = UIColor.Clear;
			
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
			base.ViewWillAppear(animated);
			
			if (SelectedRow != null)
				TableView.DeselectRow(SelectedRow, true);
		}
	}
}