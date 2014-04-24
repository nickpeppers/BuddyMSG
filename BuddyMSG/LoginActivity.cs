using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BuddyMSG
{
    [Activity(Label = "LoginActivity")]			
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginLayout);

            var buddyClient = new Buddy.BuddyClient(BuddyService.BuddyApplicationName, BuddyService.BuddyApplicationPassword);

            var emailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);

            var loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += async (sender, e) => 
            {
                try
                {
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("The text you entered is not a valid email address").SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();

                    if(string.IsNullOrEmpty(emailEditText.Text))
                    {
                        errorDialog.Show();
                        return;
                    }
                    try
                    {
                        new System.Net.Mail.MailAddress(emailEditText.Text);
                    }
                    catch
                    {
                        errorDialog.Show();
                    }
                    await buddyClient.LoginAsync(emailEditText.Text, passwordEditText.Text);
                }
                catch (Exception exc)
                {
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    errorDialog.Show();
                }
            };
        }
    }
}

