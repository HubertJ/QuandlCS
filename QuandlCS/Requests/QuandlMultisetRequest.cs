using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Types;

namespace QuandlCS.Requests
{
  public class QuandlMultisetRequest : IQuandlRequest
  {
    #region Construction

    /// <summary>
    /// 
    /// </summary>
    public QuandlMultisetRequest()
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
    /// Reset the object to be used again
    /// </summary>
    /// <param name="resetAPIKey">Flag to specify if the API key should be reset</param>
    public void Reset(bool resetAPIKey)
    {
      if (resetAPIKey)
      {
        APIKey = string.Empty;
      }

      _datacolumns = new StringBuilder();
    }

    /// <summary>
    /// Returns the request string
    /// </summary>
    /// <returns>The request string</returns>
    public string ToRequestString()
    {
      string request = string.Empty;

      try
      {
        request = CreateRequestString();
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Cannot create request string in the current state", ex);
      }

      return request;
    }

    #endregion
    
    #region QuandlMultisetRequest Members

    /// <summary>
    /// Add a column to the collection of columns to be returned
    /// </summary>
    /// <param name="datasource">The datasource</param>
    /// <param name="column">The column to add</param>
    public void AddColumn(Datacode datasource, int column)
    {
      if (_datacolumns.Length > 0)
      {
        _datacolumns.Append(',');
      }
      _datacolumns.Append(string.Format("{0}.{1}", datasource.ToDatacodeString('.'), column));
    }

    /// <summary>
    /// Add all columns for the supplied datasource
    /// </summary>
    /// <param name="datasource">The datasource</param>
    public void AddColumns(Datacode datasource)
    {
      if (_datacolumns.Length > 0)
      {
        _datacolumns.Append(',');
      }
      _datacolumns.Append(datasource.ToDatacodeString('.'));
    }

    /// <summary>
    /// The format to request the data
    /// </summary>
    public FileFormats Format
    {
      get
      {
        return _format;
      }

      set
      {
        if (_format != value)
        {
          _format = value;
        }
      }
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
      get;
      set;
    }

    /// <summary>
    /// The start date of the period that data should be returned for
    /// </summary>
    public DateTime StartDate
    {
      get
      {
        return _startDate;
      }

      set
      {
        _startDate = value;
      }
    }

    /// <summary>
    /// The end date of the period that data should be returned for
    /// </summary>
    public DateTime EndDate
    {
      get
      {
        return _endDate;
      }

      set
      {
        _endDate = value;
      }
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
      sb.Append(Constants.APIMultisetsAddress)
        .Append(TypeConverter.FileFormatToString(_format))
        .Append('?')
        .Append(Constants.APIColumns)
        .Append(_datacolumns.ToString())
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

      if (_startDate != DateTime.MinValue)
      {
        sb.Append('&')
          .Append(Constants.APIStartDate)
          .Append(TypeConverter.DateToString(_startDate));
      }

      if (_endDate != DateTime.MinValue)
      {
        sb.Append('&')
          .Append(Constants.APIEndDate)
          .Append(TypeConverter.DateToString(_endDate));
      }

      if (Format == FileFormats.CSV)
      {
        sb.Append('&')
          .Append(Constants.APIHeader)
          .Append(!Headers);
      }

      return sb.ToString();
    }

    private void ValidateData()
    {
      if (_datacolumns.Length < 0)
      {
        throw new InvalidOperationException("You must first specify datacolumns for a multiset request");
      }
    }

    #endregion

    #region Fields

    private FileFormats _format;

    private DateTime _startDate;
    private DateTime _endDate;

    private StringBuilder _datacolumns;
    
    #endregion
  }
}
