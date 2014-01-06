
namespace QuandlCS.Types
{
  /// <summary>
  /// A class to represent the data code required for downloads and metadata
  /// </summary>
  public class Datacode
  {
    /// <summary>
    /// Constructor to instantiate a datacode object using the source and code
    /// for the data required.
    /// </summary>
    /// <example>
    /// Datacode : "PRAGUESE\PX"
    /// Source   : "PRAGUESE"
    /// Code     : "PX"
    /// </example>
    public Datacode()
    {
      Source = string.Empty;
      Code = string.Empty;
    }

    /// <summary>
    /// Constructor to instantiate a datacode object using the source and code
    /// for the data required.
    /// </summary>
    /// <example>
    /// Datacode : "PRAGUESE\PX"
    /// Source   : "PRAGUESE"
    /// Code     : "PX"
    /// </example>
    /// <param name="source">The source of the data</param>
    /// <param name="code">The code to identify the data</param>
    public Datacode(string source, string code)
    {
      Source = source;
      Code = code;
    }

    /// <summary>
    /// The source of the data
    /// </summary>
    /// <example>
    /// Datacode : "PRAGUESE\PX"
    /// Source   : "PRAGUESE"
    /// </example>
    public string Source
    {
      get;
      set;
    }

    /// <summary>
    /// The source of the data
    /// </summary>
    /// <example>
    /// Datacode : "PRAGUESE\PX"
    /// Code     : "PX"
    /// </example>
    public string Code
    {
      get;
      set;
    }

    /// <summary>
    /// The full unique datacode containing the Source and Code
    /// </summary>
    public string UniqueCode
    {
      get { return string.Format(@"{0}/{1}", Source, Code); }
    }
  }
}
