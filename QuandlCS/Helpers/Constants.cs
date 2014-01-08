using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuandlCS.Helpers
{
  internal static class Constants
  {
    #region Addresses 

    internal const string APIMultisetsAddress      = "http://www.quandl.com/api/v1/multisets";
    internal const string APIDatasetsAddress       = "http://www.quandl.com/api/v1/datasets";
    internal const string APIDatasetsImportAddress = "http://www.quandl.com/api/v1/datasets/import";
    internal const string APIFavouritesAddress     = "http://www.quandl.com/api/v1/current_user/collections/datasets/favourites";

    #endregion

    #region Variables

    internal const string APIColumns               = "columns=";
    internal const string APIAuthorization         = "auth_token=";
    internal const string APISortOrder             = "sort_order=";
    internal const string APIStartDate             = "trim_start=";
    internal const string APIEndDate               = "trim_end=";
    internal const string APITransformation        = "transformation=";
    internal const string APIFrequency             = "collapse=";
    internal const string APITruncation            = "rows=";
    internal const string APIHeader                = "exclude_headers=";
    internal const string APIExcludeData           = "exclude_data=";
    internal const string APIQuery                 = "query=";

    #endregion
  }
}
