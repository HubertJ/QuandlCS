using ProgramArgumentsCS.Attributes;
using ProgramArgumentsCS.Model;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Requests;

namespace QuandlCSConsole.ProgramArguments
{
  public class FavouritesVerb
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public FavouritesVerb()
    {
    }

    #endregion

    #region Interface

    /// <summary>
    /// The download request
    /// </summary>
    public IQuandlRequest Request
    {
      get { return _request; }
    }
    
    /// <summary>
    /// Sets the file format for the request
    /// </summary>
    /// <param name="value">The value to convert into the file format</param>
    [ArgumentDetails("Format", "format", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [Help("The file format to save this requested download in", "xml", "json", "html", "csv")]
    public void SetFormat(string value)
    {
      Initialize();
      _request.Format = TypeConverter.FileFormatFromString(value);
    }

    /// <summary>
    /// Sets the api key to be used for authenticaton
    /// </summary>
    /// <param name="value">The value to try and parse to set the end date</param>
    [ArgumentDetails("API Key", "apikey", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The api key for the request", "1234-FAKEKEY-4321")]
    public string APIKey
    {
      get
      {
        return _request.APIKey;
      }
      set
      {
        Initialize();
        _request.APIKey = value;
      }
    }

    #endregion
    
    #region Implementation

    private void Initialize()
    {
      if (_request == null)
      {
        _request = new QuandlFavouritesRequest();
      }
    }

    #endregion

    #region Fields

    private QuandlFavouritesRequest _request;

    #endregion
  }
}
