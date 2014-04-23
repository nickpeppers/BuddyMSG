// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Buddy.iOS.Sample
{
	[Register ("Buddy_iOS_SampleViewController")]
	partial class Buddy_iOS_SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCheckServer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView aiWorking { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPingResult { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCheckServer != null) {
				btnCheckServer.Dispose ();
				btnCheckServer = null;
			}

			if (aiWorking != null) {
				aiWorking.Dispose ();
				aiWorking = null;
			}

			if (lblPingResult != null) {
				lblPingResult.Dispose ();
				lblPingResult = null;
			}
		}
	}
}
