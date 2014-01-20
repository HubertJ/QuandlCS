using System;
using System.Collections.Generic;
using System.Text;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Types;

namespace QuandlCS.Requests
{
  /// <summary>
  /// The class to represent a download request from Quandl
  /// </summary>
  public class QuandlDownloadRequest : IQuandlRequest
  {
    #region Construction

    public QuandlDownloadRequest()
    {
      Reset(true);
    }

    #endregion

    #region IQuandlRequest Members

    /// <summary>
    /// The API key to use for the request
    /// </summary>
    public string APIKey
    {
      get;
      set;
    }

    /// <summary>
    /// Resets the download request object
    /// </summary>
    public void Reset(bool resetAPIKey)
    {
      if (resetAPIKey)
      {
        APIKey = string.Empty;
      }

      Datacode = new Datacode();
      StartDate = DateTime.MinValue;
      EndDate = DateTime.MaxValue;
      Frequency = Frequencies.None;
      Transformation = Transformations.None;
      Truncation = 0;
      Format = FileFormats.CSV;
      Headers = true;
    }

    /// <summary>
    /// Get the download request string
    /// </summary>
    /// <returns>The download request string</returns>
    public string ToRequestString()
    {
      string request = string.Empty;

      try
      {
        request = CreateRequestString();
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Creating the request string is not possible whilst the request is in the current state", ex);
      }

      return request;
    }

    #endregion

    #region QuandlDownloadRequest Members

    /// <summary>
    /// The datacode 
    /// </summary>
    public Datacode Datacode
    {
      get;
      set;
    }

    /// <summary>
    /// The format to request the data
    /// </summary>
    public FileFormats Format
    {
      get;
      set;
    }

    /// <summary>
    /// The sort order to apply to the data
    /// </summary>
    public SortOrders Sort
    {
      get;
      set;
    }

    /// <summary>
    /// The transformation to be applied to the download request
    /// </summary>
    public Transformations Transformation
    {
      get;
      set;
    }

    /// <summary>
    /// The frequency of the data to request
    /// </summary>
    public Frequencies Frequency
    {
      get;
      set;
    }

    /// <summary>
    /// The truncation to apply to the data
    /// </summary>
    public int Truncation
    {
      get
      {
        return _truncation;
      }

      set
      {
        if (CheckValidTruncation(value) == false)
        {
          throw new ArgumentOutOfRangeException("The truncation supplied is invalid. The value must be greater than or equal to 0", "Truncation");
        }

        if (_truncation != value)
        {
          _truncation = value;
        }
      }
    }

    /// <summary>
    /// The start date of the period that data should be returned for
    /// </summary>
    public DateTime StartDate
    {
      get;
      set;
    }

    /// <summary>
    /// The end date of the period that data should be returned for
    /// </summary>
    public DateTime EndDate
    {
      get;
      set;
    }

    /// <summary>
    /// Whether or not headers should be included in the CSV data
    /// </summary>
    public bool Headers
    {
      get;
      set;
    }

    #endregion

    #region Implementation
    
    private string CreateRequestString()
    {
      ValidateData();

      StringBuilder sb = new StringBuilder();
      sb.Append(Constants.APIDatasetsAddress)
        .Append('/')
        .Append(Datacode.ToDatacodeString('/'))
        .Append(TypeConverter.FileFormatToString(Format))
        .Append('?');      

      if (APIKey != string.Empty)
      {
        sb.Append(Constants.APIAuthorization)
          .Append(APIKey)
          .Append('&');
      }

      sb.Append(Constants.APIFrequency)
        .Append(TypeConverter.FrequencyToString(Frequency))
        .Append('&')
        .Append(Constants.APITransformation)
        .Append(TypeConverter.TransformationsToString(Transformation))
        .Append('&')
        .Append(Constants.APISortOrder)
        .Append(TypeConverter.SortOrdersToString(Sort));

      if (Truncation > 0)
      {
        sb.Append('&')
          .Append(Constants.APITruncation)
          .Append(Truncation);
      }

      if (StartDate != DateTime.MinValue)
      {
        sb.Append('&')
          .Append(Constants.APIStartDate)
          .Append(TypeConverter.DateToString(StartDate));
      }

      if (EndDate != DateTime.MaxValue)
      {
        sb.Append('&')
          .Append(Constants.APIEndDate)
          .Append(TypeConverter.DateToString(EndDate));
      }

      if (Format == FileFormats.CSV)
      {
        sb.Append('&')
          .Append(Constants.APIHeader)
          .Append(!Headers);
      }

      return sb.ToString();
    }

    /// <summary>
    /// Validate the data and throw an exception if errors found
    /// </summary>
    private void ValidateData()
    {
      if (CheckValidDates() == false)
      {
        throw new InvalidOperationException("The start date of the data window must be before the end date");
      }

      if (CheckValidTruncation(_truncation) == false)
      {
        throw new InvalidOperationException("The truncation supplied is invalid");
      }
    }

    /// <summary>
    /// Validates that the dates are correct. That is, the end date must 
    /// come after the start date.
    /// </summary>
    /// <returns>True if valid, otherwise false</returns>
    private bool CheckValidDates()
    {
      return StartDate < EndDate;
    }

    /// <summary>
    /// Checks that the supplied truncation value is valid. That is it is 
    /// greater than or equal to 0. 
    /// </summary>
    /// <param name="truncation"></param>
    /// <returns></returns>
    private bool CheckValidTruncation(int truncation)
    {
      return truncation > -1;
    }

    #endregion

    #region Fields

    private int _truncation;
        
    #endregion
  }
}
