using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using QuandlCS.Interfaces;

namespace QuandlCS.Connection
{
  /// <summary>
  /// 
  /// </summary>
  public class QuandlConnection : IQuandlConnection 
  {
    #region IQuandlConnection Members

    public string Get(IQuandlGETRequestBuilder request)
    {
      string data = string.Empty;
      using (WebClient client = new WebClient())
      {
        string requestString = request.GetGETRequestString();
        data = client.DownloadString(requestString);
      }
      return data;
    }

    public string Post(IQuandlPOSTRequestBuilder request)
    {
      throw new InvalidOperationException("THIS DOESN'T WORK AT THE MOMENT");

      string data = string.Empty;
      using (WebClient client = new WebClient())
      {
        string requestString = request.GetPOSTRequestString();
        string requestData = request.GetData();
        data = client.UploadString(requestString, "POST", requestData);
      }
      return data;
    }

    public string Request(IQuandlRequestBuilder request)
    {
      string data = string.Empty;
      if (request is IQuandlGETRequestBuilder)
      {
        var requestGET = request as IQuandlGETRequestBuilder;
        data = Get(requestGET);
      }
      else if (request is IQuandlPOSTRequestBuilder)
      {
        var requestPOST = request as IQuandlPOSTRequestBuilder;
        data = Post(requestPOST);
      }
      else
      {
        throw new ArgumentException("The request supplied is not of a valid type", "request");
      }
      return data;
    }

    #endregion
  }
}
