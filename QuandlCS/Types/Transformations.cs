
namespace QuandlCS.Types
{
  /// <summary>
  /// Specifies the transformation that Quandl should apply to the data when
  /// returning the results of the request.
  /// 
  /// More information about transformations can be found at:
  /// http://www.quandl.com/help/api#Transformations
  /// </summary>
  public enum Transformations
  {
    /// <summary>
    /// Data returned corresponds to the raw data with no transformations applied 
    /// y'[i] = y[i]
    /// </summary>
    None,

    /// <summary>
    /// Data returned corresponds to the absolute difference
    /// y'[i] = y[i] - y[i-1]
    /// </summary>
    Difference,

    /// <summary>
    /// Data returned corresponds to the relative difference
    /// y'[i] = (y[i] - y[i-1])/y[i-1]
    /// </summary>
    RelativeDifference,

    /// <summary>
    /// Data returned corresponds to the cummulative amounts
    /// y'[i] = y[i] +y[i-1] + ... + y[0]
    /// </summary>
    Cumulative,

    /// <summary>
    /// Data returned corresponds to the normalized amounts
    /// y'[i] = (y[i]/y[0]) * 100
    /// </summary>
    Normalize
  }
}