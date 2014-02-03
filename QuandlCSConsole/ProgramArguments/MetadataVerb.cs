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
  public class MetadataVerb
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public MetadataVerb()
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
    /// Sets the datacode for the request
    /// </summary>
    /// <param name="value">The value to convert into the datacode</param>
    [ArgumentDetails("Datacode", "datacode", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [Help("The datacode to download for this request", @"QUANDL/EURGBP")]
    public void SetDatacode(string value)
    {
      Initialize();
      _request.Datacode = new Datacode(value, '/');
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
        _request = new QuandlMetadataRequest();
      }
    }

    #endregion

    #region Fields

    private QuandlMetadataRequest _request;

    #endregion
  }
}
