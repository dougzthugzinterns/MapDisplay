using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreLocation;
using Google.Maps;


namespace Maps
{
	public partial class GoogleMapsView : UIViewController
	{


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		Google.Maps.MapView mapView;

	
		
		public void addMarkerAtLocationWithGoogleMarker(CLLocationCoordinate2D position, string title, string snippet, UIColor color){
			var newMarker = new Marker(){
				Title = title,
				Snippet = snippet,
				Position = position,
				Icon = Google.Maps.Marker.MarkerImage(color),
				Map = mapView
			};
		}

		public void addMarkerAtLocationWithCustomMarker(CLLocationCoordinate2D position, string title, string snippet, UIImage markerIcon){
			var newMarker = new Marker(){
				Title = title,
				Snippet = snippet,
				Position = position,
				Icon = markerIcon,
				Map = mapView
			};
		}



		public override void LoadView ()
		{
			base.LoadView ();
			CameraPosition camera = CameraPosition.FromCamera (37.797865, -122.402526, 0);
			mapView = Google.Maps.MapView.FromCamera (RectangleF.Empty, camera);
			var mapBounds = mapView.Bounds;
			mapView.MyLocationEnabled = true;
			for(int i = 0; i<10; i++){
				UIColor awesomeColor = new UIColor (new MonoTouch.CoreGraphics.CGColor(0,(float)i/(float)10,0,1));
				double lat = 37.797865;
				double longt = -122.402526;
				addMarkerAtLocationWithGoogleMarker (new CLLocationCoordinate2D (lat+i*5, longt+i*5), "HEYYYYYYY", "WOOOOOOOO",awesomeColor);
				addMarkerAtLocationWithCustomMarker(new CLLocationCoordinate2D (lat+i, longt+i*5), "HEYYYYYYY", "WOOOOOOOO",new MonoTouch.UIKit.UIImage("icon.png"));

			}

			View = mapView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			mapView.StartRendering ();
		}

		public override void ViewWillDisappear (bool animated)
		{	
			mapView.StopRendering ();
			base.ViewWillDisappear (animated);
		}
	}
}

