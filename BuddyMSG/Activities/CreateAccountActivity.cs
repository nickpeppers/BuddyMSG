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
    public class CreateAccountActivity : BaseActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateAccountLayout);

            var nameEditText = FindViewById<EditText>(Resource.Id.CreateNameEditText);
            var emailEditText = FindViewById<EditText>(Resource.Id.CreateEmailEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.CreatePassword1EditText);
            var confirmPasswordEditText = FindViewById<EditText>(Resource.Id.CreatePassword2EditText);

            var createButton = FindViewById<Button>(Resource.Id.CreateCreateAccountButton);
            createButton.Click += async (sender, e) => 
            {
                try
                {
                    await viewModel.CreateUser(this, nameEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text, emailEditText.Text);
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

