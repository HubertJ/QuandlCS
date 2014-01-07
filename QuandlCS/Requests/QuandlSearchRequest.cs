using System;
using System.Text;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Types;

namespace QuandlCS.Requests
{
  public class QuandlSearchRequest : IQuandlRequestBuilder
  {
    #region Construction

    public QuandlSearchRequest()
    {
      Reset(true);
    }

    #endregion 

    #region IQuandlRequest Members

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
      
      Format = FileFormats.JSON;
      SearchQuery = string.Empty;
    }

    #endregion

    #region IQuandlGETRequestBuilder
    
    /// <summary>
    /// Get the download request string
    /// </summary>
    /// <returns>The download request string</returns>
    public string GetGETRequestString()
    {
      return CreateRequestString();
    }

    #endregion
    
    #region QuandlDownloadRequest Members

    /// <summary>
    /// The format to request the data
    /// </summary>
    public FileFormats Format
    {
      get
      {
        return _format;
      }

      set
      {
        if (_format != value)
        {
          if (value != FileFormats.XML && value != FileFormats.JSON)
          {
            throw new ArgumentException("Format", "The supplied file format is not valid for metadata requests");
          }
          _format = value;
        }
      }
    }

    /// <summary>
    /// The search query for the search request
    /// </summary>
    public string SearchQuery
    {
      get;
      set;
    }

    #endregion

    #region Implementation

    private string CreateRequestString()
    {
      ValidateData();

      StringBuilder sb = new StringBuilder();
      sb.Append(APIAddress)
        .Append(TypeConverter.FileFormatToString(_format))
        .Append('?');

      if (APIKey != string.Empty)
      {
        sb.Append(APIAuthorization)
          .Append(APIKey)
          .Append('&');
      }

      sb.Append(APIQuery)
        .Append(SearchQuery);

      return sb.ToString();
    }

    private void ValidateData()
    {
      if (string.IsNullOrWhiteSpace(SearchQuery))
      {
        throw new InvalidOperationException("A search query is required for this request");
      }
    }

    #endregion

    #region Fields

    private FileFormats _format;

    #endregion

    #region Constants

    private const string APIAddress = "http://www.quandl.com/api/v1/datasets";
    private const string APIAuthorization = "auth_token=";
    private const string APIQuery = "query=";

    #endregion
  }
}
