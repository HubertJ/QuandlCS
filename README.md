## QuandlCS

***

QuandlCS is a simple wrapper around the Quandl API to provide easy access. The library currently provides download functionality supporting simple, multiset, favourite, metadata and search request downloads.

Visit the [online reference](http://www.quandl.com/help/api) for more information about the Quandl API.

### Tutorial
The CS API is simple to use and provides type safety garuantees and basic validation on data before requesting. Interaction is based around the concept of a request with all download requests implementing a single interface. Once a request is created this can be used with the QuandlConnect object to download and return the data or to generate the request string URL (`www.quandl.com/api/v1/datasets/PRAGUESE/PX.json`) to handle manually. 

#### Types
The API has a few fundamental types that mimick Quandl variables and options. 

###### Datacode
The datacode class represents the Quandl Code that uniquely identifies each dataset. It is made up of a Source and a Code. 

```c#
Datacode code = new Datacode("PRAGUESE", "PX"); // PRAGUESE is the source, PX is the datacode
```

When used this class will validate that the source and code provided do not contain any invalid characters but will not validate that the code does exist.


###### FileFormats
The FileFormats enum represents each of the available [output formats](http://www.quandl.com/help/api#Basic+Principles) from the Quandl API. Not all of the formats will be valid for each of the different requests. (e.g. Metadata requests are only available in XML and JSON formats... this is validated by the QuandlMetadataRequest class when used)


###### Frequencies
The Frequencies enum is used to specify which [frequency collapse](http://www.quandl.com/help/api#Frequency+Collapsing) is required for the dataset being downloaded.


###### SortOrders
The SortOrders enum, as you can probably imagine, specified if the data should be sorted ascending or descending. 


###### Transformations
The Transformations enum specifies which [transformation](http://www.quandl.com/help/api#Transformations) should be applied to the before downloading. 


#### Download
The simplest and most useful request to be made is a download. 

```c#
using System;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSTest
{
  class Program
  {
    static void Main(string[] args)
    {
      QuandlDownloadRequest request = new QuandlDownloadRequest();
      request.APIKey = "1234-FAKE-KEY-4321";
      request.Datacode = new Datacode("PRAGUESE", "PX"); // PRAGUESE is the source, PX is the datacode
      request.Format = FileFormats.JSON;
      request.Frequency = Frequencies.Monthly;
      request.Truncation = 150;
      request.Sort = SortOrders.Ascending;
      request.Transformation = Transformations.Difference;

      Console.WriteLine("The request string is : {0}", request.ToRequestString());
    }
  }
}
```

#### Multiset Download
The multiset download provides an almost identical interface to the simple download documented above, but instead of taking just one datacode object it provides two methods to add columns for the multiset. The columns are downloaded in the same order as they are added to this object. 

```c#
using System;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSTest
{
  class Program
  {
    static void Main(string[] args)
    {
      QuandlMultisetRequest request = new QuandlMultisetRequest();
      request.APIKey = "1234-FAKE-KEY-4321";

      Datacode first = new Datacode("GOOG", "NASDAQ_GOOG");
      request.AddColumns(first);

      Datacode second = new Datacode("GOOG", "NASDAQ_AAPL");
      request.AddColumn(second, 4);
      
      request.Format = FileFormats.HTML;
      request.Frequency = Frequencies.Daily;
      request.Transformation = Transformations.None;
      request.StartDate = new DateTime(2000, 01, 01); // Terrible date to start as Google IPO was 19/08/2004...
      request.EndDate = new DateTime(2014, 01, 19);

      Console.WriteLine("The request string is : {0}", request.ToRequestString());
    }
  }
}
```

#### Metadata Download
The metadata download is useful for gathering the key details about a dataset. It provides a very simple interface needing only a dataset, format and an API key.  

```c#
using System;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSTest
{
  class Program
  {
    static void Main(string[] args)
    {
      QuandlMetadataRequest request = new QuandlMetadataRequest();
      request.APIKey = "1234-FAKE-KEY-4321";
      request.Datacode = new Datacode("NSE", "OIL");      
      request.Format = FileFormats.XML;

      Console.WriteLine("The request string is : {0}", request.ToRequestString());
    }
  }
}
```

:koala: