using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Buddy;
using Android.Text;

namespace Buddy.Android.Sample
{
    [Activity (Label = "Buddy.Android.Sample", MainLauncher = true)]
    public class Activity1 : Activity
    {
        const string BuddyApplicationName = "[Get your app name at dev.buddy.com]";
        const string BuddyApplicationPassword = "[Get your app password at dev.buddy.com]";

        private BuddyClient _buddyClient;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnCheckServer = FindViewById<Button> (Resource.Id.btnCheckServer);
            ProgressBar pgWorking = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            TextView   txtResult = FindViewById<TextView>(Resource.Id.txtResult);
            TextView   txtLink = FindViewById<TextView>(Resource.Id.txtHtml);

            txtLink.TextFormatted = Html.FromHtml("Create your app at <a href='http://dev.buddy.com'>dev.buddy.com</a>.");
            txtResult.Visibility = ViewStates.Invisible;

            pgWorking.Visibility = ViewStates.Invisible;

            if (BuddyApplicationName.StartsWith("[")) {

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Buddy Platform");
                builder.SetMessage( "Please go to dev.buddy.com to create an app account and get your Application Name and Application Password values to run this sample.");
                builder.SetPositiveButton("OK", (sender, e) => {});

                
                builder.Show();
                txtResult.Visibility = ViewStates.Visible;
                txtResult.Text = "Need AppName/Password.";
                btnCheckServer.Visibility = ViewStates.Invisible;
                return;
            }

            // create our client and our handler code
            this._buddyClient = new BuddyClient(BuddyApplicationName, BuddyApplicationPassword);




            btnCheckServer.Click += (sender, e) =>  {
                pgWorking.Visibility = ViewStates.Visible;
                txtResult.Visibility = ViewStates.Invisible;

                // call ping on the server
                var start = DateTime.Now;
                this._buddyClient.PingAsync()
                    .ContinueWith(r => {
                        
                        pgWorking.Visibility = ViewStates.Gone;
                        var deltaInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
                        if (r.Exception == null) {
                            txtResult.Text = String.Format("Complete! ({0:0.00}s)", deltaInSeconds); 
                        }
                        else {
                            var ex = r.Exception.InnerException;
                            var buddyException = ex as BuddyServiceException;

                            txtResult.Text = String.Format("Error: {0}.", buddyException != null ? buddyException.Error : ex.Message);
                        }
                        txtResult.Visibility = ViewStates.Visible;
                        
                    }, 
                    // make sure we call back on the same thread
                    System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously
                    );
            };
        }
    }
}


