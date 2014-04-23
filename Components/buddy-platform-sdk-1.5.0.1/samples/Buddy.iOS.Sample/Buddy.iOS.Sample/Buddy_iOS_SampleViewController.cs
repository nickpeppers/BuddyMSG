using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Buddy;

namespace Buddy.iOS.Sample
{
    public partial class Buddy_iOS_SampleViewController : UIViewController
    {
      
        BuddyClient _buddyClient = null;


        public Buddy_iOS_SampleViewController () : base ("Buddy_iOS_SampleViewController", null)
        {
        }
        
        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public const string BuddyApplicationName = "[Get your BuddyApplicationName by signing up at dev.buddy.com]";
        public const string BuddyApplicationPassword = "[Get your BuddyApplicationPassword by signing up at dev.buddy.com]";

        
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            // Perform any additional setup after loading the view, typically from a nib.

            this.aiWorking.Hidden = true;
            this.lblPingResult.Hidden = true;

            if (BuddyApplicationName.StartsWith("[")) {
                UIAlertView alert = new UIAlertView(
                    "Buddy Platform",
                    "Please go to dev.buddy.com to create an app account and get your Application Name and Application Password values to run this sample.",
                    null, 
                    "OK"
                    );
                btnCheckServer.Hidden = true;
                lblPingResult.Hidden = false;
                lblPingResult.Text = "Need AppName/Password.";
                alert.Show();
                return;
            }

            // create our client and our handler code
            this._buddyClient = new BuddyClient(BuddyApplicationName, BuddyApplicationPassword);


            this.btnCheckServer.TouchUpInside += (sender, e) =>  {
                this.aiWorking.Hidden = false;
                this.lblPingResult.Text = "";
                var start = DateTime.Now;
                this._buddyClient.PingAsync()
                    .ContinueWith(r => {
                       
                        this.aiWorking.Hidden = true;
                        var deltaInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
                        if (r.Exception == null) {
                            this.lblPingResult.Text = String.Format("Complete! ({0:0.00}s)", deltaInSeconds); 
                        }
                        else {
                            var ex = r.Exception.InnerException;
                            var buddyException = ex as BuddyServiceException;
                            this.lblPingResult.Text = String.Format("Error: {0}.", buddyException != null ? buddyException.Error : ex.Message);
                        }
                        this.lblPingResult.Hidden = false;

                    }, 
                    // make sure we call back on the same thread
                    System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously
                    );
            };





        }

    }
}

