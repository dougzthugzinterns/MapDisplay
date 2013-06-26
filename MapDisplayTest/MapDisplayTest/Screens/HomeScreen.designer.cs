// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MapDisplayTest
{
	[Register ("HomeScreen")]
	partial class HomeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton goToMapViewButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (goToMapViewButton != null) {
				goToMapViewButton.Dispose ();
				goToMapViewButton = null;
			}
		}
	}
}
