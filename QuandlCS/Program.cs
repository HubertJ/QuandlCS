using System;
using QuandlCS.Connection;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCS
{
  class Program
  {
    static void Main(string[] args)
    {
      var downloadRequests = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("PRAGUESE", "PX"),
        Format = FileFormats.HTML,
        Frequency = Frequencies.Monthly,
        Transformation = Transformations.Normalize
      };

      Console.WriteLine(downloadRequests.GetGETRequestString());
      Console.WriteLine();

      var metadataRequest = new QuandlMetadataRequest()
      {
        Datacode = new Datacode("NSE", "OIL"),
        Format = FileFormats.XML,
      };

      Console.WriteLine(metadataRequest.GetGETRequestString());
      Console.WriteLine();

      var searchRequest = new QuandlSearchRequest()
      {
        Format = FileFormats.XML,
        SearchQuery = "oil"
      };

      Console.WriteLine(searchRequest.GetGETRequestString());
      Console.WriteLine();

      var multisetRequest = new QuandlMultisetRequest()
      {
        Format = FileFormats.XML
      };

      multisetRequest.AddColumn(new Datacode("NSE", "OIL"), 1);
      multisetRequest.AddColumns(new Datacode("PRAGUESE", "PX"));
      multisetRequest.AddColumn(new Datacode("NSE", "OIL"), 1);

      Console.WriteLine(multisetRequest.GetGETRequestString());
      Console.WriteLine();

      var favouritesRequest = new QuandlFavouritesRequest()
      {
        Format = FileFormats.XML,
        APIKey = "<INSERT API KEY HERE>"
      };

      Console.WriteLine(favouritesRequest.GetGETRequestString());
      Console.WriteLine();

      var uploadRequest = new QuandlUploadRequest()
      {
        APIKey = "<INSERT API KEY HERE>"
      };

      Console.WriteLine(favouritesRequest.GetGETRequestString());
      Console.WriteLine();



      QuandlConnection connection = new QuandlConnection();
      string results = string.Empty;
      results = connection.Request(downloadRequests);
      results = connection.Request(multisetRequest);
      results = connection.Request(searchRequest);
      results = connection.Request(favouritesRequest);
      results = connection.Request(metadataRequest);
      results = connection.Request(uploadRequest);





      Console.ReadKey();
    }
  }
}
