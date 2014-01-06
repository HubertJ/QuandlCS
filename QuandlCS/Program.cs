using System;
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

      var metadataRequest = new QuandlMetadataRequest()
      {
        Datacode = new Datacode("NSE", "OIL"),
        Format = FileFormats.XML,
      };
      
      var searchRequest = new QuandlSearchRequest()
      {
        Format = FileFormats.XML,
        SearchQuery = "oil"
      };

      Console.WriteLine(downloadRequests.GetRequestString());
      Console.WriteLine();
      Console.WriteLine(metadataRequest.GetRequestString());
      Console.WriteLine();
      Console.WriteLine(searchRequest.GetRequestString());

      Console.ReadKey();
    }
  }
}
