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
    public class HomeMessageAdapter : BaseAdapter<Buddy.Message>
    {
        List<Buddy.Message> _messages;
        Activity _context;
        Buddy.AuthenticatedUser _user;

        public HomeMessageAdapter(Activity context, List<Buddy.Message> messages, Buddy.AuthenticatedUser user) : base()
        {
            _context = context;
            _messages = messages;
            _user = user;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Buddy.Message this[int position] 
        {  
            get { return _messages[position]; }
        }

        public override int Count 
        {
            get { return _messages.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.HomeMessageAdapterLayout, null);
            }
            var fromUser = _user.FindUserAsync(_messages[position].FromUserID).Result;

            view.FindViewById<TextView> (Resource.Id.HomeFromTextView).Text = fromUser.Name;
            view.FindViewById<TextView> (Resource.Id.HomeSendToEditText).Text = _messages[position].Text;
            return view;
        }

    }
}

