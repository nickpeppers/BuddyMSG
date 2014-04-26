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
    [Activity(Label = "HomeActivity")]			
    public class HomeActivity : BaseActivity<LoginViewModel>
    {
        IEnumerable<Buddy.Message> _messages;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeLayout);

            UpdateMessages();

            var listView = FindViewById<ListView>(Resource.Id.HomeMessagesListView);
            if (_messages != null)
            {
                listView.Adapter = new HomeMessageAdapter(this, _messages.ToList<Buddy.Message>(), viewModel.User);
            }

            var composeMessageButton = FindViewById<Button>(Resource.Id.HomeComposeButton);
            composeMessageButton.Click += (sender, e) => 
            {
                StartActivity(typeof(ComposeMessageActivity));
            };

            var refreshButton = FindViewById<Button>(Resource.Id.HomeRefreshButton);
            refreshButton.Click += (sender, e) => 
            {
                UpdateMessages();
                listView.Adapter = new HomeMessageAdapter(this, _messages.ToList<Buddy.Message>(), viewModel.User);
            };
        }

        protected async void UpdateMessages()
        {
            try
            {
                viewModel.IsBusy = true;
                _messages = await Buddy.MessagesTaskWrappers.GetReceivedAsync(viewModel.User.Messages);
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
            }
        }
    }
}

