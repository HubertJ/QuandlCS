
namespace QuandlCS.Types
{
  /// <summary>
  /// Specifies the time series frequency of the data returned through a download
  /// request from Quandl.
  /// 
  /// More information about file formats can be found at:
  /// http://www.quandl.com/help/api#Frequency+Collapsing
  /// </summary>
  public enum Frequencies
  {
    /// <summary>
    /// Data returned is the raw data with the highest frequency available
    /// </summary>
    None,

    /// <summary>
    /// Data returned corresponds daily values
    /// </summary>
    Daily,

    /// <summary>
    /// Data returned corresponds weekly values
    /// </summary>
    Weekly,

    /// <summary>
    /// Data returned corresponds monthly values
    /// </summary>
    Monthly,

    /// <summary>
    /// Data returned corresponds quarterly values
    /// </summary>
    Quarterly,

    /// <summary>
    /// Data returned corresponds yearly values
    /// </summary>
    Annualy
  }
}