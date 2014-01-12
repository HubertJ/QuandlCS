using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuandlCS.Types;

namespace QuandlCS.Helpers
{
  public static class TypeConverter
  {
    #region ToString

    public static string SortOrdersToString(SortOrders sort)
    {
      return sort == SortOrders.Ascending ? "asc" : "desc";
    }

    public static string FrequencyToString(Frequencies frequency)
    {
      switch (frequency)
      {
        case Frequencies.Daily:
          return "daily";
          
        case Frequencies.Weekly:
          return "weekly";

        case Frequencies.Monthly:
          return "monthly";

        case Frequencies.Quarterly:
          return "quarterly";

        case Frequencies.Annualy:
          return "annual";

        default:
          return "none";
      }
    }

    public static string TransformationsToString(Transformations transformation)
    {
      switch (transformation)
      {
        case Transformations.Normalize:
          return "normalize";

        case Transformations.Cumulative:
          return "cummul";

        case Transformations.RelativeDifference:
          return "rdiff";

        case Transformations.Difference:
          return "diff";

        default:
          return "none";
      }
    }

    public static string DateToString(DateTime date)
    {
      return date.ToString("yyyy-MM-dd");
    }

    public static string FileFormatToString(FileFormats format)
    {
      return string.Format(".{0}", format).ToLower();
    }

    #endregion

    #region FromString

    public static SortOrders SortOrdersFromString(string sort)
    {
      if (string.Equals(sort, "asc", StringComparison.InvariantCultureIgnoreCase))
      {
        return SortOrders.Ascending;
      }
      else if (string.Equals(sort, "desc", StringComparison.InvariantCultureIgnoreCase))
      {
        return SortOrders.Descending;
      }
      else
      {
        throw new ArgumentException(string.Format("The sort supplied \"{0}\" is not a valid QuandlCS sort", sort), "sort");
      }
    }

    public static Frequencies FrequencyFromString(string frequency)
    {
      if (string.Equals(frequency, "daily", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.Daily;
      }
      else if (string.Equals(frequency, "weekly", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.Weekly;
      }
      else if (string.Equals(frequency, "monthly", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.Monthly;
      }
      else if (string.Equals(frequency, "quarterly", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.Quarterly;
      }
      else if (string.Equals(frequency, "annual", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.Annualy;
      }
      else if (string.Equals(frequency, "none", StringComparison.InvariantCultureIgnoreCase))
      {
        return Frequencies.None;
      }
      else
      {
        throw new ArgumentException(string.Format("The frequency supplied \"{0}\" is not a valid QuandlCS frequency", frequency), "frequency");
      }
    }

    public static Transformations TransformationsFromString(string transformation)
    {
      if (string.Equals(transformation, "normalize", StringComparison.InvariantCultureIgnoreCase))
      {
        return Transformations.Normalize;
      }
      else if (string.Equals(transformation, "cummul", StringComparison.InvariantCultureIgnoreCase))
      {
        return Transformations.Cumulative;
      }
      else if (string.Equals(transformation, "rdiff", StringComparison.InvariantCultureIgnoreCase))
      {
        return Transformations.RelativeDifference;
      }
      else if (string.Equals(transformation, "diff", StringComparison.InvariantCultureIgnoreCase))
      {
        return Transformations.Difference;
      }
      else if (string.Equals(transformation, "none", StringComparison.InvariantCultureIgnoreCase))
      {
        return Transformations.None;
      }
      else
      {
        throw new ArgumentException(string.Format("The transformation supplied \"{0}\" is not a valid QuandlCS transformation", transformation), "transformation");
      }
    }

    public static FileFormats FileFormatFromString(string format)
    {
      if (string.Equals(format, "csv", StringComparison.InvariantCultureIgnoreCase))
      {
        return FileFormats.CSV;
      }
      else if (string.Equals(format, "xml", StringComparison.InvariantCultureIgnoreCase))
      {
        return FileFormats.XML;
      }
      else if (string.Equals(format, "html", StringComparison.InvariantCultureIgnoreCase))
      {
        return FileFormats.HTML;
      }
      else if(string.Equals(format, "json", StringComparison.InvariantCultureIgnoreCase))
      {
        return FileFormats.JSON;
      }
      else
      {
        throw new ArgumentException(string.Format("The format supplied \"{0}\" is not a valid QuandlCS format", format), "format"); 
      }
    }

    #endregion
  }
}
