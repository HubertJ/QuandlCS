
namespace QuandlCS.Interfaces
{
  /// <summary>
  /// The interface that all Quandl API Requests implement
  /// </summary>
  public interface IQuandlRequest
  {
    /// <summary>
    /// The API key to use when connecting to Quandl
    /// </summary>
    string APIKey
    {
      get;
      set;
    }

    /// <summary>
    /// Get the request string from the object
    /// </summary>
    /// <returns>The request string for this API request</returns>
    string GetRequestString();

    /// <summary>
    /// Resets the request object
    /// </summary>
    void Reset(bool resetAPIKey);
  }
}
