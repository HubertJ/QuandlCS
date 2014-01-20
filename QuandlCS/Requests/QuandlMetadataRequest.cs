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
  public class QuandlMetadataRequest : IQuandlRequest
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

    /// <summary>
    /// Get the download request string
    /// </summary>
    /// <returns>The download request string</returns>
    public string ToRequestString()
    {
      string request = string.Empty;

      try
      {
        request = CreateRequestString();
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Cannot create request string in the current state", ex);
      }

      return request;
    }

    #endregion
    
    #region QuandlMetadataRequest Members

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
      sb.Append(Constants.APIDatasetsAddress)
        .Append('/')
        .Append(_datacode.ToDatacodeString('/'))
        .Append(TypeConverter.FileFormatToString(_format))
        .Append('?');

      if (APIKey != string.Empty)
      {
        sb.Append(Constants.APIAuthorization)
          .Append(APIKey)
          .Append('&');
      }

      sb.Append(Constants.APIExcludeData)
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
  }
}
