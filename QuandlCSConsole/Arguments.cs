using System;
using ProgramArgumentsCS.Arguments;
using ProgramArgumentsCS.Attributes;
using QuandlCS.Helpers;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSConsole
{
  [ProgramDetails("QuandlCSConsole", "A simple command line utility to request download data from Quandl and save to an output file", "", "HubertJ")]
  public class Arguments
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public Arguments()
    {
      _filename = string.Empty;
      _request = new QuandlDownloadRequest();
    }

    #endregion

    #region Interface

    /// <summary>
    /// Flag to set whether the application should output to the standard
    /// stream and request input from the user
    /// </summary>
    [ArgumentDetails("Quiet", "q", ArgumentRequirements.Optional, ArgumentType.Switch)]
    [ArgumentHelp("Switch to specify if the application should display output messages and require input from the user")]
    public bool Quiet
    {
      get;
      set;
    }

    /// <summary>
    /// The filename for the output file
    /// </summary>
    [ArgumentDetails("Filename", "filename", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [ArgumentHelp("The filename of the destination to output the results of the request")]
    [ArgumentExample(@"C:\QuandlCS\EURGBP.csv")]
    public string Filename
    {
      get { return _filename; }
      set { _filename = value; }
    }

    /// <summary>
    /// The download request
    /// </summary>
    public QuandlDownloadRequest Request
    {
      get { return _request; }
    }
    
    /// <summary>
    /// Sets the datacode for the request
    /// </summary>
    /// <param name="value">The value to convert into the datacode</param>
    [ArgumentDetails("Datacode", "datacode", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [ArgumentHelp("The datacode to download for this request")]
    [ArgumentExample(@"QUANDL/EURGBP")]
    public void SetDatacode(string value)
    {
      _request.Datacode = new Datacode(value, '/');
    }

    /// <summary>
    /// Sets the file format for the request
    /// </summary>
    /// <param name="value">The value to convert into the file format</param>
    [ArgumentDetails("Format", "format", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [ArgumentHelp("The file format to save this requested download in")]
    [ArgumentExample("xml")]
    [ArgumentExample("json")]
    [ArgumentExample("html")]
    [ArgumentExample("csv")]
    public void SetFormat(string value)
    {
      _request.Format = TypeConverter.FileFormatFromString(value);
    }

    /// <summary>
    /// Sets the sort order for the request
    /// </summary>
    /// <param name="value">The value to convert into the sort order</param>
    [ArgumentDetails("Sort", "sort", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The sort order to apply to downloaded data for this request")]
    [ArgumentExample("asc")]
    [ArgumentExample("desc")]
    public void SetSort(string value)
    {
      _request.Sort = TypeConverter.SortOrdersFromString(value);
    }

    /// <summary>
    /// Sets the transformation for the request
    /// </summary>
    /// <param name="value">The value to convert into the transformation</param>
    [ArgumentDetails("Transformation", "transformation", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The transformation to apply to downloaded data for this request")]
    [ArgumentExample("none")]
    [ArgumentExample("diff")]
    [ArgumentExample("rdiff")]
    [ArgumentExample("cummul")]
    [ArgumentExample("normalize")]
    public void SetTransformation(string value)
    {
      _request.Transformation = TypeConverter.TransformationsFromString(value);
    }

    /// <summary>
    /// Sets the frequency for the request
    /// </summary>
    /// <param name="value">The value to convert into the frequency</param>
    [ArgumentDetails("Frequency", "frequency", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The frequency of the data request")]
    [ArgumentExample("none")]
    [ArgumentExample("daily")]
    [ArgumentExample("weekly")]
    [ArgumentExample("monthly")]
    [ArgumentExample("quarterly")]
    [ArgumentExample("annual")]
    public void SetFrequency(string value)
    {
      _request.Frequency = TypeConverter.FrequencyFromString(value);
    }

    /// <summary>
    /// Sets the truncation for the request
    /// </summary>
    /// <param name="value">The value to convert into the truncation</param>
    [ArgumentDetails("Truncation", "truncation", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The data row truncation to apply to this request")]
    [ArgumentExample("0")]
    [ArgumentExample("1")]
    [ArgumentExample("10")]
    [ArgumentExample("100")]
    public void SetTruncation(string value)
    {
      _request.Truncation = int.Parse(value);
    }

    /// <summary>
    /// Sets the start date of the data window
    /// </summary>
    /// <param name="value">The value to try and parse to set the start date</param>
    [ArgumentDetails("Start Date", "start-date", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The start date of the data window to download")]
    [ArgumentExample("2010-04-25")]
    public void SetStartDate(string value)
    {
      _request.StartDate = DateTime.Parse(value);
    }

    /// <summary>
    /// Sets the end date of the data window
    /// </summary>
    /// <param name="value">The value to try and parse to set the end date</param>
    [ArgumentDetails("End Date", "end-date", ArgumentRequirements.Optional, ArgumentType.Parameter)]
    [ArgumentHelp("The end date of the data window to download")]
    [ArgumentExample("2010-04-25")]
    public void SetEndDate(string value)
    {
      _request.EndDate = DateTime.Parse(value);
    }

    #endregion

    #region Fields

    private string _filename;

    private QuandlDownloadRequest _request;

    #endregion
  }
}
