
using System;
namespace QuandlCS.Types
{
  /// <summary>
  /// A class to represent the data code required for downloads and metadata
  /// </summary>
  public class Datacode
  {
    #region Construction

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
      : this(string.Empty, string.Empty)
    {
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
      _source = source;
      _code = code;
    }

    /// <summary>
    /// Constructor to instantiate a datacode object using the full datacode
    /// </summary>
    /// <example>
    /// Datacode : "PRAGUESE\PX"
    /// Source   : "PRAGUESE"
    /// Code     : "PX"
    /// </example>
    /// <param name="datacode">The full datacode</param>
    /// <param name="code">The character separating the source and the code</param>
    public Datacode(string datacode, char separator)
    {
      var datacodeParts = datacode.Split(separator);

      if (datacodeParts.Length != 2)
      {
        throw new ArgumentException("The datacode is not formated correctly and cannot be split", "datacode");
      }

      Source = datacodeParts[0];
      Code = datacodeParts[1];
    }

    #endregion

    #region Interface

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
    public string ToDatacodeString(char separator)
    {
      try
      {
        Validate("Source", _source);
        Validate("Code", _code);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Unable to convert datacode to string in the current state", ex);
      }

      return string.Format(@"{0}{1}{2}", Source, separator, Code);
    }

    /// <summary>
    /// Checks whether this datacode object is in a valid state
    /// </summary>
    /// <returns>True if valid, otherwise false</returns>
    public bool IsValid()
    {
      if (CheckValid(_source) == false || CheckValid(_code) == false)
      {
        return false;
      }
      return true;
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Validate that the code supplied is valid
    /// </summary>
    /// <param name="propertyName">The name of the property being set</param>
    /// <param name="data">The data being set</param>
    private void Validate(string propertyName, string data)
    {
      if (CheckValid(data) == false)
      {
        throw new ArgumentException("The value supplied contains invalid characters", propertyName);
      }
    }

    /// <summary>
    /// Checks whether the data supplied is valid
    /// </summary>
    /// <param name="data">The data to validate</param>
    /// <returns>True if valid, otherwise false</returns>
    private bool CheckValid(string data)
    {
      if (string.IsNullOrWhiteSpace(data) == true)
      {
        return false;
      }

      foreach (char character in data)
      {
        if (((char.IsLetter(character) && char.IsUpper(character))
          || (char.IsDigit(character)) || char.IsPunctuation(character)) == false)
        {
          return false;
        }
      }
      return true;
    }

    #endregion

    #region Fields

    private string _source;

    private string _code;

    #endregion
  }
}
