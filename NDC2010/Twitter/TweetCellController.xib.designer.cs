// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace NDC2010 {
	
	
	// Base type probably should be MonoTouch.UIKit.UIViewController or subclass
	[MonoTouch.Foundation.Register("TweetCellController")]
	public partial class TweetCellController {
		
		private MonoTouch.UIKit.UITableViewCell __mt_cell;
		
		private MonoTouch.UIKit.UIImageView __mt_imageView;
		
		private MonoTouch.UIKit.UILabel __mt_textLabel;
		
		private MonoTouch.UIKit.UILabel __mt_dateLabel;
		
		private MonoTouch.UIKit.UILabel __mt_nameLabel;
		
		#pragma warning disable 0169
		[MonoTouch.Foundation.Connect("cell")]
		private MonoTouch.UIKit.UITableViewCell cell {
			get {
				this.__mt_cell = ((MonoTouch.UIKit.UITableViewCell)(this.GetNativeField("cell")));
				return this.__mt_cell;
			}
			set {
				this.__mt_cell = value;
				this.SetNativeField("cell", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("imageView")]
		private MonoTouch.UIKit.UIImageView imageView {
			get {
				this.__mt_imageView = ((MonoTouch.UIKit.UIImageView)(this.GetNativeField("imageView")));
				return this.__mt_imageView;
			}
			set {
				this.__mt_imageView = value;
				this.SetNativeField("imageView", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("textLabel")]
		private MonoTouch.UIKit.UILabel textLabel {
			get {
				this.__mt_textLabel = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("textLabel")));
				return this.__mt_textLabel;
			}
			set {
				this.__mt_textLabel = value;
				this.SetNativeField("textLabel", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("dateLabel")]
		private MonoTouch.UIKit.UILabel dateLabel {
			get {
				this.__mt_dateLabel = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("dateLabel")));
				return this.__mt_dateLabel;
			}
			set {
				this.__mt_dateLabel = value;
				this.SetNativeField("dateLabel", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("nameLabel")]
		private MonoTouch.UIKit.UILabel nameLabel {
			get {
				this.__mt_nameLabel = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("nameLabel")));
				return this.__mt_nameLabel;
			}
			set {
				this.__mt_nameLabel = value;
				this.SetNativeField("nameLabel", value);
			}
		}
	}
}
