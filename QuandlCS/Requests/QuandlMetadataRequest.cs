using System;
using System.Text;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Types;

namespace QuandlCS.Requests
{
  /// <summary>
  /// A class to represent a metadata request from Quandl
  /// </summary>
  public class QuandlMetadataRequest : IQuandlRequestBuilder
  {
    #region Construction

    public QuandlMetadataRequest()
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
      
      Datacode = new Datacode();
      Format = FileFormats.JSON;
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
    /// The datacode 
    /// </summary>
    public Datacode Datacode
    {
      get
      {
        return _datacode;
      }

      set
      {
        if (_datacode != value)
        {
          _datacode = value;
        }
      }
    }

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

    #endregion

    #region Implementation

    private string CreateRequestString()
    {
      ValidateData();

      StringBuilder sb = new StringBuilder();
      sb.Append(APIAddress)
        .Append(_datacode.UniqueCode)
        .Append(TypeConverter.FileFormatToString(_format))
        .Append('?');

      if (APIKey != string.Empty)
      {
        sb.Append(APIAuthorization)
          .Append(APIKey)
          .Append('&');
      }

      sb.Append(APIExcludeData)
        .Append(true);

      return sb.ToString();
    }

    private void ValidateData()
    {
      if (string.IsNullOrWhiteSpace(_datacode.Source))
      {
        throw new InvalidOperationException("The datacode for this request does not have a Source specified.");
      }

      if (string.IsNullOrWhiteSpace(_datacode.Code))
      {
        throw new InvalidOperationException("The datacode for this request does not have a Code specified.");
      }
    }

    #endregion

    #region Fields

    private Datacode _datacode;
    private FileFormats _format;

    #endregion

    #region Constants

    private const string APIAddress = "http://www.quandl.com/api/v1/datasets/";
    private const string APIAuthorization = "auth_token=";
    private const string APIExcludeData = "exclude_data=";

    #endregion
  }
}
