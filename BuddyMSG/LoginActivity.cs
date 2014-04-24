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
    public class LoginActivity : BaseActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginLayout);

            var nameEditText = FindViewById<EditText>(Resource.Id.NameEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);

            var loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += async (sender, e) => 
            {
                try
                {
                    await viewModel.Login(this, nameEditText.Text, passwordEditText.Text);
                    //StartActivity(typeof());
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

