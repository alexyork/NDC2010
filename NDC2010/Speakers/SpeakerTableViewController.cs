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
	[Register("SpeakerTableViewController")]
	public partial class SpeakerTableViewController : UITableViewController
    {
		private static NSString CELL_ID = new NSString("SpeakerTableCell");
		
		protected SpeakerPresenter Presenter;
	
		public SpeakerTableViewController(Speaker speaker) : base(UITableViewStyle.Grouped)
		{
			Presenter = new SpeakerPresenter();
			Presenter.Speaker = speaker;
			Presenter.Sessions = (UIApplication.SharedApplication.Delegate as AppDelegate).Sessions;
		}
        
		class TableSource : NDC2010DetailsTableViewSource
		{
			private SpeakerTableViewController _tvc;
		
			public TableSource(SpeakerTableViewController tvc)
			{
				_tvc = tvc;
			}
		
			public override int RowsInSection(UITableView tableView, int section)
			{
				// TODO: cache GetSessions() locally?
				
				if (section == 2)
					return _tvc.Presenter.GetSessions().Length;
				return 1;
			}
			
			public override int NumberOfSections(UITableView tableView)
			{
				return 3;
			}
			
			public override string TitleForHeader(UITableView tableView, int section)
			{
				switch (section)
				{
					case 0:
						return _tvc.Presenter.GetHeadingTextForName();
					case 1:
						return _tvc.Presenter.GetHeadingTextForBio();
					case 2:
						return _tvc.Presenter.GetHeadingTextForSessions();
					default:
						return "";
				}
			}
	
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = DequeueOrCreateTableCell(tableView, indexPath, CELL_ID);
				
				cell.TextLabel.Text = GetCellText(indexPath);
		
				return cell;
			}
			
			public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return GetCellHeightForRow(GetCellText(indexPath), tableView,indexPath);
			}
			
			private string GetCellText(NSIndexPath indexPath)
			{
				if (indexPath.Section == 0)
					return _tvc.Presenter.Speaker.Name;
				if (indexPath.Section == 1)
					return _tvc.Presenter.Speaker.Info;
				
				// TODO: use the cached GetSessions()
				if (indexPath.Section == 2)
					return _tvc.Presenter.GetSessions().ElementAt(indexPath.Row).Title;
				
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