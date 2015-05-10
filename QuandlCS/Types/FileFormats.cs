
namespace QuandlCS.Types
{
  /// <summary>
  /// Specifies the different "file" formats that the requested data from Quandl
  /// should be returned in. 
  /// 
  /// More information about file formats can be found at:
  /// https://www.quandl.com/help/api#Data-Formats
  /// </summary>
  public enum FileFormats
  {
    /// <summary>
    /// Comma Seperated Variables
    /// </summary>
    CSV,

    /// <summary>
    /// Plain unformatted HTML text
    /// </summary>
    HTML,

    /// <summary>
    /// Valid JSON document
    /// </summary>
    JSON,

    /// <summary>
    /// Well structured XML document
    /// </summary>
    XML
  }
}