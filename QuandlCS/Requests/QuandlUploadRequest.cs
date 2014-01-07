using QuandlCS.Interfaces;

namespace QuandlCS.Requests
{
  public class QuandlUploadRequest : IQuandlPOSTRequestBuilder
  {
    #region IQuandlPOSTRequestBuilder Members

    public string GetPOSTRequestString()
    {
      throw new System.NotImplementedException();
    }
    
    public string GetData()
    {
      throw new System.NotImplementedException();
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
