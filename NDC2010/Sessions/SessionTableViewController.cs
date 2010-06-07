using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Logic;
using NDC2010.Logic.Managers;
using NDC2010.Logic.Presenters;

namespace NDC2010
{
	[Register("SessionTableViewController")]
	public partial class SessionTableViewController : NDC2010TableViewController
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
			//private UIButton _addToScheduleButton;
			
			protected MyScheduleManager MyScheduleManager
			{
				get { return (UIApplication.SharedApplication.Delegate as AppDelegate).MyScheduleManager; }
			}
		
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
			
			private string GetTitleForHeader(int section)
			{
				return (section == 0)
					? _tvc.Presenter.GetHeadingTextForSessionInfo()
					: _tvc.Presenter.GetHeadingTextForSessionDescription();
			}
			
			public override UIView GetViewForHeader(UITableView tableView, int section)
			{
				var headingText = GetTitleForHeader(section);
				return _tvc.GetViewForHeader(section, headingText);
			}
			
			public override float GetHeightForHeader(UITableView tableView, int section)
			{
				return 44f;
			}
				/*
				if (section == 0)
				{
					_addToScheduleButton = UIButton.FromType(UIButtonType.Custom);
					_addToScheduleButton.Frame = new RectangleF(280, 10, 30, 30);
					_addToScheduleButton.BackgroundColor = _tvc.Presenter.Session.IsSelected
						? UIColor.FromPatternImage(UIImage.FromFile("Images/star-selected.png"))
						: UIColor.FromPatternImage(UIImage.FromFile("Images/star-unselected.png"));
					_addToScheduleButton.TouchUpInside += delegate {
						ToggleSessionFromSchedule();
					};
					customView.AddSubview(_addToScheduleButton);
				}
				*/
			/*
			private void ToggleSessionFromSchedule()
			{
				if (_tvc.Presenter.Session.IsSelected)
				{
					_addToScheduleButton.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/star-unselected.png"));
					MyScheduleManager.RemoveFromSchedule(_tvc.Presenter.Session);
				}
				else
				{
					_addToScheduleButton.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/star-selected.png"));
					MyScheduleManager.AddToSchedule(_tvc.Presenter.Session);
				}
			}
			*/
			
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell;
				
				if (CellHasDetailsLabel(indexPath))
				{
					cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_WITH_DETAIL_ID, UITableViewCellStyle.Subtitle, false);
					cell.TextLabel.Text = _tvc.Presenter.GetTextForSpeakers();
					cell.DetailTextLabel.Text = _tvc.Presenter.Session.GetDayTimeTrackInfo();
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
			
			protected override UIFont GetFont(NSIndexPath indexPath)
			{
				if (indexPath.Section == 0 && indexPath.Row == 0)
					return NDC2010Fonts.TitleFont;
				else if (indexPath.Section == 0 && indexPath.Row == 1)
					return NDC2010Fonts.SubtitleFont;
				return NDC2010Fonts.CellFont;
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
	}
}