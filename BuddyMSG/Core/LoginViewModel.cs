using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace BuddyMSG
{
    public class LoginViewModel : BaseViewModel
    {
        public Buddy.AuthenticatedUser User { get; set; }

        public async Task Login(Context context, string username, string password)
        {
            IsBusy = true;
            try
            {
                var user = await service.Login(username, password);
                User = user;
                //settings.User = User;
                //settings.IsLoggedIn = true;
                //settings.Save();
            }
            catch(Exception exc)
            {
                var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task CreateUser(Context context, string name, string password1, string password2, string email)
        {
            IsBusy = true;
            try
            {
                var emailErrorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("The text you entered is not a valid email address").SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                if(string.IsNullOrEmpty(name))
                {
                    var emptyNameErrorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("The name field has been left blank.").SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    emptyNameErrorDialog.Show();
                    return;
                }
                if(string.IsNullOrEmpty(email))
                {
                    emailErrorDialog.Show();
                    return;
                }
                try
                {
                    new System.Net.Mail.MailAddress(email);
                }
                catch
                {
                    emailErrorDialog.Show();
                }
                if(string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(password2))
                {
                    var emptyPasswordErrorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("A password field has been left blank. Your password must not be blank.").SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    emptyPasswordErrorDialog.Show();
                    return;
                }
                else if(password1 != password2)
                {
                    var matchPasswordErrorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("The passwords you entered do not match.").SetPositiveButton("Okay", (sender1, e1) =>
                    {

                    }).Create();
                    matchPasswordErrorDialog.Show();
                    return;
                }
                await service.CreateUser(name, password1, email);
            }
            catch(Exception exc)
            {
                var errorDialog = new AlertDialog.Builder(context).SetTitle("Oops!").SetMessage("Something went wrong " + exc.ToString()).SetPositiveButton("Okay", (sender1, e1) =>
                {

                }).Create();
                errorDialog.Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

