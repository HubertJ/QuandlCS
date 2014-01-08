using System.Text;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;

namespace QuandlCS.Requests
{
  public class QuandlUploadRequest : IQuandlPOSTRequestBuilder
  {
    #region IQuandlPOSTRequestBuilder Members

    public string GetPOSTRequestString()
    {
      return Constants.APIDatasetsImportAddress;
    }
    
    public string GetData()
    {
      var sb = new StringBuilder();

      sb.AppendLine("code: FOO");
      sb.AppendLine("name: My Dataset");
      sb.AppendLine("description: This is a short time series");
      sb.AppendLine("headings: Date,Temperature (C),Rainfall (mm)");
      sb.AppendLine("2012-09-01, 22, 0");
      sb.AppendLine("2012-09-02, 23, 5");
      sb.AppendLine("2012-09-03, 18, 1");

      return sb.ToString();
    }

    #endregion

    #region IQuandlRequestBuilder Members

    /// <summary>
    /// The API key to use for the request
    /// </summary>
    public string APIKey
    {
      get;
      set;
    }

    /// <summary>
    /// Resets the download request object
    /// </summary>
    public void Reset(bool resetAPIKey)
    {
      if (resetAPIKey)
      {
        APIKey = string.Empty;
      }
    }

    #endregion
  }
}
