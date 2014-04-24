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

            SetContentView (Resource.Layout.MainLayout);

            var loginButton = FindViewById<Button> (Resource.Id.MainLoginButton);
            var createAccountButton = FindViewById<Button> (Resource.Id.MainCreateAccountButton);

            loginButton.Click += (sender, e) =>
            {
                StartActivity(typeof(LoginActivity));
			};

            createAccountButton.Click += (sender, e) => 
            {
                StartActivity(typeof(CreateAccountActivity));
            };
		}
	}
}


