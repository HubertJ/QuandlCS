using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgramArgumentsCS;
using ProgramArgumentsCS.Errors;

using QuandlCS.Connection;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSConsole
{
  class Program
  {
    private static void Main(string[] args)
    {
      Arguments arguments = new Arguments();
      var argumentParser = new ArgumentParser<Arguments>(arguments, args);

      if (argumentParser.PendingHelp == true)
      {
        argumentParser.DisplayHelp();
      }
      else if (argumentParser.CriticalErrors == true && arguments.Quiet == false)
      {
        argumentParser.DisplayErrors(Severity.Critical | Severity.Warning | Severity.Information);
      }
      else
      {
        if (arguments.Quiet == false)
        {
          Console.WriteLine("Submitting request to Quandl...");
        }

        RequestToFile(arguments.Filename, arguments.Request);

        if (arguments.Quiet == false)
        {
          Console.WriteLine("Download complete. Please press any key to exit.");
          Console.ReadKey();
        }
      }

      return;
    }

    private static void RequestToFile(string filename, IQuandlRequestBuilder request)
    {
      QuandlConnection connection = new QuandlConnection();
      var data = connection.Request(request);

      using (StreamWriter writer = new StreamWriter(filename))
      {
        writer.Write(data);
      }
    }
  }
}
