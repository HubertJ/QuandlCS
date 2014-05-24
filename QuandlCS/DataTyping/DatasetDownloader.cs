using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using QuandlCS.Connection;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCS.DataTyping
{
  public class DatasetDownloader<T> where T : new()
  {
    public IEnumerable<T> Download(DownloadOptions options)
    {
      IQuandlRequest request = CreateRequest(options);

      IQuandlConnection connection = new QuandlConnection();
      string downloadedData = connection.Request(request);

      IEnumerable<T> datapoints = ExtractData(downloadedData);
      return datapoints;
    }

    private Datacode GetDatacode()
    {
      DatasetAttribute attribute = (DatasetAttribute)typeof(T).GetCustomAttribute(typeof(DatasetAttribute), false);
      return new Datacode(attribute.Source, attribute.Code);
    }

    private IQuandlRequest CreateRequest(DownloadOptions options)
    {
      Datacode datacode = GetDatacode();
      QuandlDownloadRequest request = new QuandlDownloadRequest()
      {
        APIKey = options.API,
        StartDate = options.Start,
        EndDate = options.End,
        Frequency = options.Frequency,
        Transformation = options.Transformation,
        Format = FileFormats.XML,
        Truncation = options.Truncation,
        Datacode = datacode
      };
      return request;
    }

    private IEnumerable<T> ExtractData(string downloadedData)
    {
      ColumnExtractor<T> extractor = new ColumnExtractor<T>(downloadedData);
      return extractor.GetData();
    }
  }
}
