using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuandlCS.Interfaces
{
  public interface IQuandlGETRequestBuilder : IQuandlRequestBuilder
  {
    /// <summary>
    /// Get the request string from the object
    /// </summary>
    /// <returns>The request string for this API request</returns>
    string GetGETRequestString();
  }
}
