using System;
using System.Text;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Types;

namespace QuandlCS.Requests
{
  public class QuandlFavouritesRequest : IQuandlRequest
  {
    #region Construction

    public QuandlFavouritesRequest()
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
    
    #region QuandlFavouriteRequest Members

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
      sb.Append(Constants.APIFavouritesAddress)
        .Append(TypeConverter.FileFormatToString(_format))
        .Append('?')
        .Append(Constants.APIAuthorization)
        .Append(APIKey);

      return sb.ToString();
    }

    private void ValidateData()
    {
      if (string.IsNullOrWhiteSpace(APIKey))
      {
        throw new InvalidOperationException("An authorization token is required for this request");
      }
    }

    #endregion

    #region Fields

    private FileFormats _format;

    #endregion
  }
}
