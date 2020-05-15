﻿using Foundation;
using UIKit;

namespace MobileApp.iOS
{
	[Register(nameof(AppDelegate))]
	public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");

			Xamarin.Forms.Forms.Init();
			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
