using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;

namespace NDC2010
{
	public class NDC2010TableViewController : UIViewController
	{
		protected UITableView TableView { get; set; }
		protected UITableViewStyle Style { get; set; }
		protected NSIndexPath SelectedRow { get; set; }
		
		private Dictionary<int, UIView> _headingViews = new Dictionary<int, UIView>();
		
		public NDC2010TableViewController() : this(UITableViewStyle.Plain)
		{
		}
		
		public NDC2010TableViewController(UITableViewStyle style)
		{
			Style = style;
		}
		
		protected UITableViewCell DequeueOrCreateTableCell(UITableView tableView, string cellId)
		{
			return DequeueOrCreateTableCell(tableView, cellId, UITableViewCellStyle.Default);
		}
		
		protected UITableViewCell DequeueOrCreateTableCell(UITableView tableView, string cellId, UITableViewCellStyle style)
		{
			var cell = tableView.DequeueReusableCell(cellId);
			
			if (cell == null)
			{
				cell = new UITableViewCell(style, cellId);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			
			return cell;
		}
		
		public void PushSessionViewController(Session session, NSIndexPath indexPath)
		{
			var sessionTableViewController = new SessionTableViewController(session);
			NavigationController.PushViewController(sessionTableViewController, true);
			
			SelectedRow = indexPath;
		}
		
		protected UIView GetViewForHeader(int section, string headingText)
		{
			return GetViewForHeader(section, headingText, null);
		}
		
		protected UIView GetViewForHeader(int section, string headingText, UIView subView)
		{
			if (_headingViews.ContainsKey(section))
				return _headingViews[section];
			
			var customView = new UIView(new RectangleF(10, 0, 300, 44));
				
			var headerLabel = new UILabel();
			headerLabel.BackgroundColor = UIColor.Clear;
			headerLabel.TextColor = NDC2010Colors.DarkRed;
			headerLabel.Font = UIFont.BoldSystemFontOfSize(16f);
			headerLabel.Frame = new RectangleF(20, 0, 250, 44);
			headerLabel.Text = headingText;
				
			customView.AddSubview(headerLabel);
			
			if (subView != null)
				customView.AddSubview(subView);
			
			_headingViews[section] = customView;
			
			return customView;
		}
		
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			
			if (SelectedRow != null)
				TableView.DeselectRow(SelectedRow, true);
		}
	}
}