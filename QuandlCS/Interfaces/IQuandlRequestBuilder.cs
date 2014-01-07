
namespace QuandlCS.Interfaces
{
  /// <summary>
  /// The interface that all Quandl API Request Builders implement
  /// </summary>
  public interface IQuandlRequestBuilder
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
    /// Resets the request object
    /// </summary>
    void Reset(bool resetAPIKey);
  }
}
