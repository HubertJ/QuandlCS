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
  public class DownloadVerb
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public DownloadVerb()
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
    /// Sets the sort order for the request
    /// </summary>
    /// <param name="value">The value to convert into the sort order</param>
    [ArgumentDetails("Sort", "sort", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The sort order to apply to downloaded data for this request", "asc", "desc")]
    public void SetSort(string value)
    {
      Initialize();
      _request.Sort = TypeConverter.SortOrdersFromString(value);
    }

    /// <summary>
    /// Sets the transformation for the request
    /// </summary>
    /// <param name="value">The value to convert into the transformation</param>
    [ArgumentDetails("Transformation", "transformation", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The transformation to apply to downloaded data for this request", "none", "diff", "rdiff", "cummul", "normalize")]
    public void SetTransformation(string value)
    {
      Initialize();
      _request.Transformation = TypeConverter.TransformationsFromString(value);
    }

    /// <summary>
    /// Sets the frequency for the request
    /// </summary>
    /// <param name="value">The value to convert into the frequency</param>
    [ArgumentDetails("Frequency", "frequency", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The frequency of the data request", "none", "daily", "weekly", "monthly", "quarterly", "annual")]
    public void SetFrequency(string value)
    {
      Initialize();
      _request.Frequency = TypeConverter.FrequencyFromString(value);
    }

    /// <summary>
    /// Sets the truncation for the request
    /// </summary>
    /// <param name="value">The value to convert into the truncation</param>
    [ArgumentDetails("Truncation", "truncation", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The data row truncation to apply to this request", "0", "1", "10","100")]
    public void SetTruncation(string value)
    {
      Initialize();
      _request.Truncation = int.Parse(value);
    }

    /// <summary>
    /// Sets the start date of the data window
    /// </summary>
    /// <param name="value">The value to try and parse to set the start date</param>
    [ArgumentDetails("Start Date", "start-date", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The start date of the data window to download", "2010-04-25")]
    public void SetStartDate(string value)
    {
      Initialize();
      _request.StartDate = DateTime.Parse(value);
    }

    /// <summary>
    /// Sets the end date of the data window
    /// </summary>
    /// <param name="value">The value to try and parse to set the end date</param>
    [ArgumentDetails("End Date", "end-date", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [Help("The end date of the data window to download", "2010-04-25")]
    public void SetEndDate(string value)
    {
      Initialize();
      _request.EndDate = DateTime.Parse(value);
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
        _request = new QuandlDownloadRequest();
      }
    }

    #endregion

    #region Fields

    private QuandlDownloadRequest _request;

    #endregion
  }
}
