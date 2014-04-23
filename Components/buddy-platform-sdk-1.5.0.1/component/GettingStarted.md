# Getting Started

## Create a Buddy account

Go to [http://dev.buddy.com](http://dev.buddy.com) to create an application account.  Note your *BuddyApplicationName* and *BuddyApplicationPassword*, available once you create an application by clicking the key icon in your application list.

## Start your project

Create your project and create some *const* variables to hold your BuddyApplicationName and BuddyApplicationPassword:

	public class MyClass {
		public const string BuddyApplicationName     = "[Your application name]";
		public const string BuddyApplicationPassword = "[Your app password]";
	}

## Add a component reference to Json.NET

The Buddy Platform SDK requires Newtonsoft's Json.NET at runtime.  Add a reference to this component by:

1. In the Solution pane, right click on "Components"
2. Choose Get More Components...
3. Find and click "Json.NET"
4. Click "Add to App" to install the component

## Call Buddy APIs.


	public void DoSomething() {
		
		var buddyClient = new Buddy.BuddyClient(MyClass.BuddyApplicationName, MyClass.BuddyApplicationPassword);
		
		// log in a user
		buddyClient.LoginAsync(username, password).ContinueWith(r => {
				
			user.PhotoAlbums.GetAsync("Hawaii Photos").ContinueWith(r2 => {
				PhotoAlbum album = r2.Result;
				
				// add a photo
				Stream photoStream = LoadSomeLocalPhoto();
				album.AddPictureAsync(photoStream, "My great photo", 47.68, -122.2);
			});
		});
	}

## Check the Developer Portal for Analytics Data

Once you've launched your app, you can then go back to the [Buddy Developer Portal](http://dev.buddy.com) and see how your users are using it.

The Buddy Developer Portal allows you to search and view users, photos, checkins, and other data that Buddy collects.



