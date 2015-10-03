# Feefo.NET
[!(https://raw.githubusercontent.com/kevbite/Feefo.NET/master/feefo.png)] A Simple Feefo .NET Client API Wrapper

[![install from nuget](http://img.shields.io/nuget/v/Feefo.svg?style=flat-square)](https://www.nuget.org/packages/Feefo)
[![downloads](http://img.shields.io/nuget/dt/Feefo.svg?style=flat-square)](https://www.nuget.org/packages/Feefo)
[![Build status](https://ci.appveyor.com/api/projects/status/1pivqncn1tol0xvi/branch/master?svg=true)](https://ci.appveyor.com/project/kevbite/feefo-net/branch/master)


## Getting started
Feefo.NET can be installed via the package manager console by executing the following commandlet

```powershell
PM> Install-Package Feefo
```

Once we've got the Feefo package installed, we need to create a `FeefoClient` object, this is the client that we will use for all interactions to Feefo.
The `FeefoClient` requires a `FeefoSettings` to passed in to its constructor which contains the logon details.

```csharp
var feefoSettings = new FeefoSettings("www.examplesupplier.com");
var client = new FeefoClient(feefoSettings);
```

You can also specify the BaseUri within the FeefoSettings if you wish to connect through your own layer of caching:
```csharp
var feefoSettings = new FeefoSettings(new Uri("http://feefo.examplesupplier.com/feefo/xmlfeed.jsp"), "www.examplesupplier.com");
```

## Fetching feedback
To fetch feedback from feefo we can call the `GetFeedbackAsync` method on the `FeefoClient`:

```csharp
var response = await client.GetFeedbackAsync();
```

You can also vary what Feefo sends back by passing in a `FeedbackRequest` object in to the `GetFeedbackAsync` method:

```csharp
var feedbackRequest = new FeedbackRequest()
{
    Limit = 50,
    Mode = Mode.ServiceAndProduct,
    Sort = new Sort(SortBy.Date, Order.Ascending),
    Since = Since.Month
};

var response = await client.GetFeedbackAsync(feedbackRequest);
```

### Client response
The `response` contains a `FeedbackList` which contains a list of `Feedback` and `Summary`.

Each feedback is the feedback submitted by the customer which will contains the following properties:

| Property    | Description                                                                                   |
| ----------- | --------------------------------------------------------------------------------------------- |
| FeedbackId  | A unique ID for the feedback.  |
| Count       | Integer representing the position of the item of feedback in the returned results.   |
| Date        | The date that the feedback was left.   |
| DateTime    | The date and time that the feedback was left.   |
| Description | The description of the item the customer is leaving feedback on.   |
| ProductCode | The unique product reference for this order item in Feefo, also known as the vendor ref or product search code. In retail scenarios, this is usually the SKU.   |
| Link        | The URL of the product page on the supplier's site.   |
| FacebookShareLink  | The URL to share this item of feedback on Facebook.   |
| AdditionalItems    | Contains other products the customer bought.  |
| Item               | The description of an additional product the customer bought.   |
| ReviewRating       | The rating supplied by the customer.   |
| ServiceRating      | The service rating supplied by the customer.   |
| ProductRating      | The product rating supplied by the customer.   |
| CustomerComment    | This will be the full comment that the customer left about the service they received, the product they bought, or both.  |
| ShortCustomerComment | A shortened version of the customer comment, ending in an ellipsis (...)   |
| VendorComment | The full vendor reply to the customer's service comment. |
| ShortVendorComment | A shortened version of the vendor's reply, ending in an ellipsis (...)  |
| FurtherCommentsThread | Contains all vendor comments, and all follow-up customer comments |

The `Summary` is a summary of the account with summary details on the request:

| Property            | Description   |
| ------------------- | ------------- |
| Mode                | Shows if the feed mode has been set to show 'product' or 'service' feedback. |
| VendorLogon         | The supplier's Feefo logon. |
| TotalServiceCount   | Count of all the service feedbacks that have been received for the supplier. |
| TotalProductCount   | Count of all the product feedbacks received for the supplier. |
| Count               | The count of feedbacks that have been received. |
| SupplierLogo        | An http link to display the supplier's logo as stored within Feefo. |
| Title               | A field, suggested for use as a page title, containing the name of the supplier. |
| Best                | The highest rating given in the range of reviews returned by the query. |
| Worse               | The lowest rating given in the range of reviews returned by the query. |
| Average             | The average rating given to the reviews. |
| Start               | The start number of the first feedback in the returned feedback list – usually 1 but may change if multiple pages are requested. |
| Limit               | The number of feedbacks returned in the query |
| ServiceExcellent    | An integer with the number of service feedbacks rated as Excellent |
| ServiceGood    | An integer with the number of service feedbacks rated as Good |
| ServicePoor    | An integer with the number of service feedbacks rated as Poor |
| ServiceBad    | An integer with the number of service feedbacks rated as Bad |
| ProductExcellent    | An integer with the number of product feedbacks rated as Excellent |
| ProductGood    | An integer with the number of product feedbacks rated as Good |
| ProductPoor    | An integer with the number of product feedbacks rated as Poor |
| ProductBad    | An integer with the number of product feedbacks rated as Bad |
| TotalResponses | A count of every single feedback response recorded against the supplier. |
| FeedGeneration | The date and time of the feed generation |

## Contributing

 1. Fork
 1. Hack!
 1. Pull Request





