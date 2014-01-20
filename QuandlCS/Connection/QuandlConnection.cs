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

    private string Get(IQuandlRequest request)
    {
      string data = string.Empty;
      using (WebClient client = new WebClient())
      {
        string requestString = request.ToRequestString();
        data = client.DownloadString(requestString);
      }
      return data;
    }

    private string Post(IQuandlUploadRequest request)
    {
      throw new InvalidOperationException("THIS DOESN'T WORK AT THE MOMENT");

      //string data = string.Empty;
      //using (WebClient client = new WebClient())
      //{
      //  string requestString = request.GetPOSTRequestString();
      //  string requestData = request.GetData();
      //  data = client.UploadString(requestString, "POST", requestData);
      //}
      //return data;
    }

    public string Request(IQuandlRequest request)
    {
      string data = string.Empty;
      if (request is IQuandlRequest)
      {
        var requestGET = request as IQuandlRequest;
        data = Get(requestGET);
      }
      else if (request is IQuandlUploadRequest)
      {
        var requestPOST = request as IQuandlUploadRequest;
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
