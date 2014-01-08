using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuandlCS.Interfaces
{
  public interface IQuandlConnection
  {
    /// <summary>
    /// Connect and submit a GET request
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <returns>The returned string</returns>
    string Get(IQuandlGETRequestBuilder request);

    /// <summary>
    /// Connect and submit a POST request
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <returns>The returned string</returns>
    string Post(IQuandlPOSTRequestBuilder request);

    /// <summary>
    /// Connect and submit a request to Quandl
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <returns>The returned string</returns>
    string Request(IQuandlRequestBuilder request);
  }
}
