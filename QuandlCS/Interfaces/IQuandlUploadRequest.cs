
namespace QuandlCS.Interfaces
{
  public interface IQuandlUploadRequest : IQuandlRequest
  {
    /// <summary>
    /// Gets the data for this API request
    /// </summary>
    /// <returns>The data</returns>
    string GetData();
  }
}
