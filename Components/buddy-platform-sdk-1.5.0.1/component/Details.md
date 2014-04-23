# Buddy SDK

## Introduction

Buddy enables developers to build engaging, cloud-connected apps without having to write, test, manage or scale server-side code or infrastructure. We noticed that most mobile app developers end up writing the same code over and over again.  User management, photo management, geolocation checkins, metadata, and more.  

Buddy's easy-to-use, scenario-focused APIs let you spend more time building your app, and less time worrying about backend infrastructure.  

Let us handle that stuff for you!

## Features

For developers the Buddy Platform offers turnkey support for features like the following:

* *User Accounts* - create, delete, authenticate users.
* *Photos* - add photos, search photos, share photos with other users.
* *GeoLocation* - checkin, search for places, list past checkins.
* *Push Notifications* - easily send push notifications to iOS, Android, or Microsoft devices.
* *Messaging* - send messages to other users, create message groups.
* *Friends* - set up social relationships between users with friends lists.
* *Game Scores, Metadata, and Boards* - Keep track of game stores and states for individual users as well as across users.
* *Commerce* - Offer items for in-app purchase via Facebook Commerce.
* *And more* - Checkout the rest of the offering at [buddy.com/developers](http://buddy.com/developers/).


## How It works

Getting rolling with the Buddy SDK is very easy.  First you'll need to go to [dev.buddy.com](http://dev.buddy.com), to create an account and an application.  This will create an application entry and a key pair consisting of an *Application Name* and an *Application Password*.

Once you have those, you just create a BuddyClient instance, and call methods on it.

    using Buddy;
    
    // ...
    
    // create the client
    var client = new BuddyClient("MyApplicationName", "MyApplicationPassword");
    
    // create a user
    client.CreateUserAsync("username","password").ContinueWith(r => {
        var user = r.Result;
        
        // upload a profile photo
        Stream photoStream = GetSomePhoto();
        user.AddProfilePhotoAsync(photoStream);
    });
    
See Getting Started for more information.

## Publisher Analytics

Buddy is more than just a backend service.  Because our APIs are scenario-based, we collect deep information about how users are using applications.  With that information, we can generate a rich portfolio of analytic data, ranging from when and where users are using your applicaiton to what types of devices they are using it on.  

For more information, see [Buddy for Publishers](http://buddy.com/publishers/).

## Docs

Full documentation for Buddy's services are available at [Buddy.com](http://buddy.com/documentation)