using System;
using MonoTouch.UIKit;

namespace NDC2010
{
	public class NDC2010TableViewController : UIViewController
	{
		protected UITableView TableView { get; set; }
		protected UITableViewStyle Style { get; set; }
		
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
	}
}
