using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NDC2010
{
	public partial class TweetCellController : UIViewController
	{
		public TweetCellController() : base("TweetCellController", null)
		{
		}
		
		public UITableViewCell Cell
		{
			get { return cell; }
		}
		
		public UILabel TextLabel
		{
			get { return textLabel; }
			set { textLabel = value; }
		}
		
		public UILabel DateLabel
		{
			get { return dateLabel; }
			set { dateLabel = value; }
		}
		
		public UILabel NameLabel
		{
			get { return nameLabel; }
			set { nameLabel = value; }
		}
		
		public UIImageView ImageView
		{
			get { return imageView; }
			set { imageView = value; }
		}
		
		public string AuthorImageUrl
		{
			get;
			set;
		}
	}
}