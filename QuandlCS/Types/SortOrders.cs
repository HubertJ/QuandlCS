
namespace QuandlCS.Types
{
  /// <summary>
  /// Specifies the sort order that should be applied to the dates of the data
  /// being returned by Quandl.
  /// 
  /// More information about file formats can be found at:
  /// https://www.quandl.com/help/api#Data-Manipulation
  /// </summary>
  public enum SortOrders
  {
    /// <summary>
    /// Data returned is in ascending order
    /// </summary>
    Ascending,

    /// <summary>
    /// Data returned is in descending order
    /// </summary>
    Descending
  }
}