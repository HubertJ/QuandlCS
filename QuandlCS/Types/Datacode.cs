
using System;
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
      get
      {
        return _source;
      }

      set
      {
        if (_source != value)
        {
          Validate("Source", value);
          _source = value;
        }
      }
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
      get
      {
        return _code;
      }

      set
      {
        if (_code != value)
        {
          Validate("Code", value);
          _code = value;
        }
      }
    }

    /// <summary>
    /// The full unique datacode containing the Source and Code
    /// </summary>
    public string GetDatacode(char separator)
    {
      return string.Format(@"{0}{1}{2}", Source, separator, Code);
    }

    /// <summary>
    /// Validate that the code supplied is valid
    /// </summary>
    /// <param name="propertyName">The name of the property being set</param>
    /// <param name="data">The data being set</param>
    private void Validate(string propertyName, string data)
    {
      foreach (char character in data)
      {
        if (((char.IsLetter(character) && char.IsUpper(character))
          || (char.IsDigit(character))) == false)
        {
          throw new ArgumentException("The code supplied contains invalid characters", propertyName);
        }
      }
    }

    private string _source;

    private string _code;
  }
}
