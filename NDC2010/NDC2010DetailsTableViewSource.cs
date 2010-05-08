using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NDC2010
{
	public class NDC2010DetailsTableViewSource : UITableViewSource
	{
		protected static UIFont TitleFont = UIFont.FromName("Helvetica", 16.0f);
		protected static UIFont CellFont = UIFont.FromName("Helvetica", 14.0f);
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
		
		public float GetCellHeightForRow(string cellText, UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("Getting cell height for section " + indexPath.Section + " row " + indexPath.Row);
			
			UIFont font = GetFont(indexPath);
			
			SizeF labelSize = tableView.StringSize(cellText,
			                                       font,
			                                       BaseSize,
			                                       UILineBreakMode.WordWrap);
			
			// Return height plus padding for the top and bottom
			return CELL_PADDING + labelSize.Height + CELL_PADDING;
		}
		
		/*
		Extract and override to test UI padding logic
		
		protected virtual SizeF StringSizeOf(UITableView tableView, ..)
		{
			return tableView.StringSize(cellText,
			                                       font,
			                                       BaseSize,
			                                       UILineBreakMode.WordWrap);
			
		}
		*/
		protected UIFont GetFont(NSIndexPath indexPath)
		{
			switch (indexPath.Section)
			{
				case 0:
					return TitleFont;
				default:
					return CellFont;
			}
		}
		
		protected UITableViewCell DequeueOrCreateTableCell(UITableView tableView, NSIndexPath indexPath, string cellId)
		{
			var cell = tableView.DequeueReusableCell(cellId);
			
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
				cell.TextLabel.Lines = 100;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				cell.TextLabel.UserInteractionEnabled = false;
				cell.Frame = new RectangleF(CELL_PADDING, CELL_PADDING, 320, 200);
			}
			
			cell.TextLabel.MinimumFontSize = cell.TextLabel.Font.PointSize;
			cell.TextLabel.Font = GetFont(indexPath);
			
			return cell;
		}
	}
}