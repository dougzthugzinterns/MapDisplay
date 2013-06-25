// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Maps
{
	[Register ("HomeScreen")]
	partial class HomeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton nativeMapButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton googleMapButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (nativeMapButton != null) {
				nativeMapButton.Dispose ();
				nativeMapButton = null;
			}

			if (googleMapButton != null) {
				googleMapButton.Dispose ();
				googleMapButton = null;
			}
		}
	}
}
