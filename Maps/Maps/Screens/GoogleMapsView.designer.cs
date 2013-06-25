// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Maps
{
	[Register ("GoogleMapsView")]
	partial class GoogleMapsView
	{
		[Outlet]
		MonoTouch.MapKit.MKMapView mapViewOutlet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mapViewOutlet != null) {
				mapViewOutlet.Dispose ();
				mapViewOutlet = null;
			}
		}
	}
}
