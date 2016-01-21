using System;
using UIKit;
using CoreGraphics;

namespace CollapsibleListView
{
	public class CollapsibleListViewCell : UITableViewCell
	{
		private static bool isIpad = AppDelegate.DeviceType == Enums.DeviceType.IPAD;
		public static int HEIGHT = 70;
		public static int ParentItemLeftPadding = 20;
		public static int ChildItemLeftPadding = 45;
		public static int FontSize = 18;

		public static float WIDTH = (int)(Math.Min (AppDelegate.DeviceWidth, AppDelegate.DeviceHeight) / 2);

		UIView seperatorLine{ get; set; }

		UILabel lbl_Title { get; set; }

		public UIImageView img_RightIcon { get; set; }


		public bool IsSelected { get; set; }

		public string Title {
			set {
				lbl_Title.Text = value;
			}
		}

		public CollapsibleListViewCell (UITableViewCellStyle style, string identifier, CGRect tblFrame) : base (style, identifier)
		{
			if (tblFrame != null) {
				WIDTH = (float)tblFrame.Width;
			}

			this.BackgroundColor = UIColor.Clear;

			ContentView.Frame = new CGRect (0, 0, WIDTH, HEIGHT);
			ContentView.BackgroundColor = UIColor.FromRGB (242, 242, 242);
			UIView SubContainerView = new UIView (ContentView.Frame);
			SubContainerView.ClipsToBounds = true;
			SubContainerView.AutoresizingMask = UIViewAutoresizing.All;
			ContentView.AutoresizingMask = UIViewAutoresizing.All;
			seperatorLine = new UIView (new CGRect (0, HEIGHT - 1, WIDTH, 1));
			seperatorLine.BackgroundColor = UIColor.LightGray;
			seperatorLine.Alpha = 0.3f;
			seperatorLine.AutoresizingMask = UIViewAutoresizing.All;


			lbl_Title = new UILabel (new CGRect (ChildItemLeftPadding, ContentView.Frame.Y, ContentView.Frame.Width, ContentView.Frame.Height));
			//lbl_Title.BackgroundColor = UIColor.Yellow;
			lbl_Title.TextColor = UIColor.DarkGray;
			lbl_Title.Font = UIFont.BoldSystemFontOfSize (FontSize);
			lbl_Title.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			img_RightIcon = new UIImageView (new CGRect (
				ContentView.Frame.Width - CollapsibleListViewCell.HEIGHT - 20, 
				0,
				CollapsibleListViewCell.HEIGHT,
				CollapsibleListViewCell.HEIGHT
			));
			img_RightIcon.ContentMode = UIViewContentMode.Center;
			img_RightIcon.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;


			SubContainerView.AddSubview (lbl_Title);
			SubContainerView.AddSubview (seperatorLine);
			SubContainerView.AddSubview (img_RightIcon);

			ContentView.AddSubview (SubContainerView);

		}

	}
}

