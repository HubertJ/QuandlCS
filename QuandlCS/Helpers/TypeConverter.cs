using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuandlCS.Types;

namespace QuandlCS.Helpers
{
  internal static class TypeConverter
  {
    internal static string SortOrdersToString(SortOrders sort)
    {
      return sort == SortOrders.Ascending ? "asc" : "desc";
    }

    internal static string FrequencyToString(Frequencies frequency)
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

    internal static string TransformationsToString(Transformations transformation)
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

    internal static string DateToString(DateTime date)
    {
      return date.ToString("yyyy-MM-dd");
    }

    internal static string FileFormatToString(FileFormats format)
    {
      return string.Format(".{0}", format).ToLower();
    }
  }
}
