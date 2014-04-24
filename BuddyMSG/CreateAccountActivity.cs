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
    [Activity(Label = "CreateAccountActivity")]			
    public class CreateAccountActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateAccountLayout);

            var buddyClient = new Buddy.BuddyClient(BuddyService.BuddyApplicationName, BuddyService.BuddyApplicationPassword);

            var nameEditText = FindViewById<EditText>(Resource.Id.CreateNameEditText);
            var emailEditText = FindViewById<EditText>(Resource.Id.CreateEmailEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.CreatePassword1EditText);
            var confirmPasswordEditText = FindViewById<EditText>(Resource.Id.CreatePassword2EditText);

            var createButton = FindViewById<Button>(Resource.Id.CreateCreateAccountButton);
            createButton.Click += async (sender, e) => 
            {
                try
                {
                    var emailErrorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("The text you entered is not a valid email address").SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();

                    if(string.IsNullOrEmpty(emailEditText.Text))
                    {
                        emailErrorDialog.Show();
                        return;
                    }
                    try
                    {
                        new System.Net.Mail.MailAddress(emailEditText.Text);
                    }
                    catch
                    {
                        emailErrorDialog.Show();
                    }
                    if(string.IsNullOrEmpty(passwordEditText.Text) || string.IsNullOrEmpty(confirmPasswordEditText.Text))
                    {
                        var emptyPasswordErrorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("A password field has been left blank. Your password must not be blank.").SetPositiveButton("Okay", (sender1, e1) =>
                        {

                        }).Create();
                        emptyPasswordErrorDialog.Show();
                        return;
                    }
                    else if(passwordEditText.Text != confirmPasswordEditText.Text)
                    {
                        var matchPasswordErrorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("The passwords you entered do not match.").SetPositiveButton("Okay", (sender1, e1) =>
                        {

                        }).Create();
                        matchPasswordErrorDialog.Show();
                        return;
                    }
                    await buddyClient.CreateUserAsync(nameEditText.Text, passwordEditText.Text, Buddy.UserGender.Any, 0,emailEditText.Text,Buddy.UserStatus.Any,false,false,string.Empty);
                    Finish();
                }
                catch(Exception exc)
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

