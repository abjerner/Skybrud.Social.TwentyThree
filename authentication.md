---
order: -5
---

# Authentication

As TwentyThree is a hosted solution, your organisation likely has a custom domain - eg. `video.clientname.com`. If you go to the `/profile/applications` page of your custom domain, you can create a new application, which will let you gain access to your TwentyThree data through the API.

The API uses OAuth 1.0a for authentication, which means your created application will have a **consumer key** and **consumer secret** that identifies your application, and an **access token** and **access token secret** that identifies you as a user. You will need all four to access the API using this package.

The package revolves around the **TwentyThreeOAuthClient** and **TwentyThreeHttpService**. The client is the low level implementation of the API for handling the request to the API and OAuth 1.0a communication, while the service is a strongly typed implementation that builds on top of the client.

You can initialize new client and service instances as shown below:

```cshtml
@using Skybrud.Social.TwentyThree
@using Skybrud.Social.TwentyThree.OAuth
@inherits WebViewPage

@{

    // Initialize a new OAuth client
    TwentyThreeOAuthClient client = new TwentyThreeOAuthClient {
        ConsumerKey = "Your consumer key",
        ConsumerSecret = "Your consumer secret",
        Token = "Your access token",
        TokenSecret = "Your access token secret"
    };

    // Initialize a new service instance
    TwentyThreeHttpService service = TwentyThreeHttpService.CreateFromOAuthClient(client);

}
```