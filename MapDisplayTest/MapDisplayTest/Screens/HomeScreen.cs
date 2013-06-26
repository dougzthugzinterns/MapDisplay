using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MapDisplayTest
{
	public partial class HomeScreen : UIViewController
	{
		//MapView mapView;
		GoogleMapView googleView;
		public HomeScreen () : base ("HomeScreen", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.goToMapViewButton.TouchUpInside += (sender, e) => {
				if(this.googleView == null){
					googleView = new GoogleMapView();

				}
				this.NavigationController.PushViewController(googleView, true);
			};			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

