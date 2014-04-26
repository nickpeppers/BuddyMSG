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
    [Activity(Label = "ComposeMessageActivity")]			
    public class ComposeMessageActivity : BaseActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ComposeMessageLayout);

            var toEditText = FindViewById<EditText>(Resource.Id.ComposeToEditText);
            var messageEditText = FindViewById<EditText>(Resource.Id.ComposeMessageEditText);

            var sendButton = FindViewById<Button>(Resource.Id.ComposeSendButton);
            sendButton.Click += async (sender, e) => 
            {
                try
                {
                    if(string.IsNullOrEmpty(toEditText.Text) || string.IsNullOrEmpty(messageEditText.Text))
                    {
                        var emptyDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("One or more fields have been left blank!").SetPositiveButton("Okay", (sender1, e1) =>
                        {

                        }).Create();
                        emptyDialog.Show();
                        return;
                    }

                    var sendToUser = viewModel.User.FindUser(toEditText.Text).Result;
                    if(sendToUser != null)
                    {
                        viewModel.IsBusy = true;

                        await Buddy.MessagesTaskWrappers.SendAsync(viewModel.User.Messages, sendToUser, messageEditText.Text, viewModel.User.ApplicationTag);
                    }
                    else
                    {
                        var userNotFoundDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("The user you entered could not be found!").SetPositiveButton("Okay", (sender1, e1) =>
                        {

                        }).Create();
                        userNotFoundDialog.Show();
                    }
                }
                catch(Exception exc)
                {
                    var errorDialog = new AlertDialog.Builder(this).SetTitle("Oops!").SetMessage("Error loading Messages!" + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    errorDialog.Show();
                }
                finally
                {
                    viewModel.IsBusy = false;
                    Finish();
                }
            };
        }
    }
}

