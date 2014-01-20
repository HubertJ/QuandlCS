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
    /// Connect and submit a request to Quandl
    /// </summary>
    /// <param name="request">The request to send</param>
    /// <returns>The returned string</returns>
    string Request(IQuandlRequest request);
  }
}
