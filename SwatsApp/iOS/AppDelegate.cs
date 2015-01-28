using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SwatsApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 153, 204); //#0099cc
			UINavigationBar.Appearance.TintColor = UIColor.Black;

			UITabBar.Appearance.BarTintColor = UIColor.FromRGB(102, 153, 0); //#669900
			UITabBar.Appearance.TintColor = UIColor.White;

			return base.FinishedLaunching (app, options);
		}
	}
}

