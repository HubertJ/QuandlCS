
namespace QuandlCS.Interfaces
{
  public interface IQuandlPOSTRequestBuilder : IQuandlRequestBuilder
  {
    /// <summary>
    /// Get the request string from the object
    /// </summary>
    /// <returns>The request string for this API request</returns>
    string GetPOSTRequestString();

    /// <summary>
    /// Gets the data for this API request
    /// </summary>
    /// <returns>The data</returns>
    string GetData();
  }
}
