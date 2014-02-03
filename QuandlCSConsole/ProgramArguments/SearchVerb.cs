using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramArgumentsCS.Attributes;
using ProgramArgumentsCS.Model;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSConsole.ProgramArguments
{
  public class SearchVerb
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public SearchVerb()
    {
    }

    #endregion

    #region Interface

    /// <summary>
    /// The request
    /// </summary>
    public IQuandlRequest Request
    {
      get { return _request; }
    }
    
    /// <summary>
    /// Sets the datacode for the request
    /// </summary>
    /// <param name="value">The value to convert into the datacode</param>
    [ArgumentDetails("SearchQuery", "query", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [Help("The search query to send to Quandl", @"OIL")]
    public string SearchQuery
    {
      get
      {
        return _request.SearchQuery;
      }

      set
      {
        Initialize();
        _request.SearchQuery = value;
      }
    }

    /// <summary>
    /// Sets the file format for the request
    /// </summary>
    /// <param name="value">The value to convert into the file format</param>
    [ArgumentDetails("Format", "format", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [Help("The file format to save this requested download in", "xml", "json")]
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
        _request = new QuandlSearchRequest();
      }
    }

    #endregion

    #region Fields

    private QuandlSearchRequest _request;

    #endregion
  }
}
