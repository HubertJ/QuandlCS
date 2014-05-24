using System;
using QuandlCS.Types;

namespace QuandlCS.DataTyping
{
  /// <summary>
  /// Class to represent the download options for typed data downloads
  /// </summary>
  public class DownloadOptions
  {
    public DownloadOptions()
    {
      API = string.Empty;
      Start = DateTime.MinValue;
      End = DateTime.MaxValue;
      Frequency = Frequencies.None;
      Transformation = Transformations.None;
      Truncation = 0;
    }

    /// <summary>
    /// The API key for the download
    /// </summary>
    public string API
    {
      get;
      set;
    }

    /// <summary>
    /// The start date of the data download
    /// </summary>
    public DateTime Start
    {
      get;
      set;
    }

    /// <summary>
    /// The end date of the data download
    /// </summary>
    public DateTime End
    {
      get;
      set;
    }

    /// <summary>
    /// The frequency of the downloaded data
    /// </summary>
    public Frequencies Frequency
    {
      get;
      set;
    }

    /// <summary>
    /// The transform to be applied to the downloaded data
    /// </summary>
    public Transformations Transformation
    {
      get;
      set;
    }

    /// <summary>
    /// The truncation to apply to the data
    /// </summary>
    public int Truncation
    {
      get;
      set;
    }
  }  
}
