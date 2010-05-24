using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NDC2010
{
	public abstract class NDC2010DetailsTableViewSource : UITableViewSource
	{
		protected static SizeF BaseSize = new SizeF(280f, 1000.0f);
		
		protected const int CELL_PADDING = 10;
		
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			throw new Exception("This method must be overridden in derived types");
		}
		
		public override int RowsInSection(UITableView tableView, int section)
		{
			throw new Exception("This method must be overridden in derived types");
		}
		
		protected abstract UIFont GetFont(NSIndexPath indexPath);
		
		public float GetCellHeightForRow(string cellText, UITableView tableView, NSIndexPath indexPath)
		{
			UIFont font = GetFont(indexPath);
			
			SizeF labelSize = tableView.StringSize(cellText, font, BaseSize, UILineBreakMode.WordWrap);
			
			// Return height plus padding for the top and bottom
			return CELL_PADDING + labelSize.Height + CELL_PADDING;
		}
		
		protected UITableViewCell DequeueOrCreateTableCell(UITableView tableView, NSIndexPath indexPath, string cellId)
		{
			return DequeueOrCreateTableCell(tableView, indexPath, cellId, UITableViewCellStyle.Default, false);
		}
		
		protected UITableViewCell DequeueOrCreateTableCell(UITableView tableView, NSIndexPath indexPath, string cellId, UITableViewCellStyle style, bool clickable)
		{
			var cell = tableView.DequeueReusableCell(cellId);
			
			if (cell == null)
			{
				cell = new UITableViewCell(style, cellId);
				cell.TextLabel.Lines = 100;
				cell.SelectionStyle = clickable ? UITableViewCellSelectionStyle.Blue : UITableViewCellSelectionStyle.None;
				cell.Accessory = clickable ? UITableViewCellAccessory.DisclosureIndicator : UITableViewCellAccessory.None;
				cell.TextLabel.Font = GetFont(indexPath);
				cell.Frame = new RectangleF(CELL_PADDING, CELL_PADDING, 320, 200);
			}
			
			return cell;
		}
	}
}