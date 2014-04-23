using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BuddyMSG
{
	[Activity (Label = "BuddyMSG", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

            var loginButton = FindViewById<Button> (Resource.Id.LoginButton);
            var createAccountButton = FindViewById<Button> (Resource.Id.CreateAccountButton);

            loginButton.Click += (sender, e) =>
            {
                //StartActivity(typeof());
			};

            createAccountButton.Click += async (sender, e) => 
            {
                //StartActivity(typeof());
            };
		}
	}
}


