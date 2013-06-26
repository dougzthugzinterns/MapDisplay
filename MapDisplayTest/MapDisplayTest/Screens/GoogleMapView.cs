using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.CoreLocation;
using Google.Maps;


namespace MapDisplayTest
{
	public partial class GoogleMapView : UIViewController
	{
		public GoogleMapView () : base ("GoogleMapView", null)
		{
		}

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

		public int getZoomLevel(double minLat, double maxLat, double minLong, double maxLong, float mapWidth, float mapHeight){
			float mapdisplay = Math.Min (mapHeight, mapWidth);
			int earthRadiusinKm = 6371;
			double degToRadDivisor = 57.2958;
			double dist = (earthRadiusinKm * Math.Acos (Math.Sin(minLat / degToRadDivisor) * Math.Sin(maxLat / degToRadDivisor) + 
			                                            (Math.Cos (minLat / degToRadDivisor)  * Math.Cos (maxLat / degToRadDivisor) * Math.Cos ((maxLong / degToRadDivisor) - (minLong / degToRadDivisor)))));
			Console.WriteLine ("Dist: "+dist);
			double zoom = Math.Floor (8 - Math.Log(1.6446 * dist / Math.Sqrt(2 * (mapdisplay * mapdisplay))) / Math.Log (2));
			if(minLat == maxLat && minLong == maxLong){zoom = 11;}
			Console.WriteLine ("Zoom Level:"+zoom);
			return (int) zoom;
		}

		public override void LoadView ()
		{
			base.LoadView ();
			CameraPosition camera = CameraPosition.FromCamera (37.797865, -122.402526,0);
			mapView = Google.Maps.MapView.FromCamera (RectangleF.Empty, camera);
			mapView.MyLocationEnabled = true;
			float minLong = 180.0f;
			float maxLong = -180.0f;
			float minLat = 90.0f;
			float maxLat = -90.0f;
			for (int i = 0; i<10; i++) {
				UIColor awesomeColor = new UIColor (new MonoTouch.CoreGraphics.CGColor(0,(float)i/(float)10,0,1));
				float lat = (float)(37.797865 + i * 0.001);
				float longt = (float)(-122.402526 + i * 0.001);
				if (maxLong < longt) {
					maxLong = longt;
				}
				if (minLong > longt) {
					minLong = longt;
				}
				if (maxLat < lat) {
					maxLat = lat;
				}
				if (minLat > lat) {
					minLat = lat;
				}

			}

			Console.WriteLine ("Map View Height: "+mapViewOutlet.Frame.Size.Height);
			Console.WriteLine ("Map View Width: "+mapViewOutlet.Frame.Size.Width);

			addMarkerAtLocationWithGoogleMarker (new CLLocationCoordinate2D (minLat, maxLong), "Lower Right hand Corner", "WOOOOOOOO", UIColor.Cyan);
			addMarkerAtLocationWithGoogleMarker (new CLLocationCoordinate2D (maxLat, minLong), "Upper Left hand Corner", "WOOOOOOOO", UIColor.Cyan);

			Console.WriteLine ("Max Lat and Long: "+maxLat+" "+maxLong);
			Console.WriteLine ("Min Lat and Long: "+minLat+" "+minLong);
			CLLocationCoordinate2D coord1 = new CLLocationCoordinate2D (maxLat, minLong);
			CLLocationCoordinate2D coord2 = new CLLocationCoordinate2D (minLat, maxLong);
			mapView.MoveCamera(CameraUpdate.FitBounds(new CoordinateBounds(coord1, coord2)));		
			Console.WriteLine ("Zoom Level: "+getZoomLevel (minLat,maxLat,minLong,maxLong,mapViewOutlet.Frame.Size.Width,mapViewOutlet.Frame.Size.Height));
			mapView.MoveCamera (CameraUpdate.ZoomToZoom((float) (getZoomLevel (minLat,maxLat,minLong,maxLong,mapViewOutlet.Frame.Size.Width,mapViewOutlet.Frame.Size.Height))));
			View = mapView;


		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
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

