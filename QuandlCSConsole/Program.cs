using System;
using System.IO;
using ProgramArgumentsCS.Errors;
using ProgramArgumentsCS.Errors.Commands;
using ProgramArgumentsCS.Parser;
using QuandlCS.Connection;
using QuandlCS.Interfaces;
using QuandlCSConsole.ProgramArguments;

namespace QuandlCSConsole
{
  class Program
  {
    private static void Main(string[] args)
    {
      Setup(args);

      if (HandleHelp())
      {
        return;
      }

      if (HandleErrors())
      {
        return;
      }
      
      string filename = arguments.Filename;
      IQuandlRequest request = arguments.Request;

      if (request != null)
      {
        Print("Submitting request to Quandl...");

        RequestToFile(filename, request);

        Print("Request complete.");
      }
      else
      {
        Print("No request object specified");
      }

      WaitForExit();

      return;
    }

    #region Implementation

    /// <summary>
    /// Setup the objects that will be used by the main program at startup
    /// </summary>
    /// <param name="args"></param>
    private static void Setup(string[] args)
    {
      arguments = new Arguments();
      argumentParser = new ArgumentParser<Arguments>(arguments, args);
    }

    /// <summary>
    /// Handle anything to do with displaying the help
    /// </summary>
    /// <returns>true if help displayed, otherwise false</returns>
    private static bool HandleHelp()
    {
      if (argumentParser.PendingHelp == true)
      {
        argumentParser.DisplayHelp();
        return true;
      }
      return false;
    }

    /// <summary>
    /// Handle anything to do with errors
    /// </summary>
    /// <returns>True if critical errors were found, otherwise false</returns>
    private static bool HandleErrors()
    {
      bool criticalErrors = argumentParser.CriticalErrors;

      if ((argumentParser.CriticalErrors
        || argumentParser.InformationalErrors
        || argumentParser.WarningErrors)
          && arguments.Quiet == false)
      {
        argumentParser.HandleErrors(Severity.Critical | Severity.Warning | Severity.Information, new ConsolePrintCommand());
      }

      return criticalErrors;
    }

    /// <summary>
    /// Print a message to console if we allow for output
    /// </summary>
    /// <param name="message">The message to print</param>
    private static void Print(string message)
    {
      if (arguments.Quiet == false)
      {
        Console.WriteLine(message);
      }
    }

    /// <summary>
    /// Wait for user input before exiting
    /// </summary>
    private static void WaitForExit()
    {
      if (arguments.Quiet == false)
      {
        Console.WriteLine("Please press any key to exit.");
        Console.ReadKey();
      }
    }

    /// <summary>
    /// Implementation! Connected to Quandl, request the data and then save to a file
    /// </summary>
    /// <param name="filename">The filename to save the output to</param>
    /// <param name="request">The request to make to Quandl</param>
    private static void RequestToFile(string filename, IQuandlRequest request)
    {
      QuandlConnection connection = new QuandlConnection();
      var data = connection.Request(request);

      using (StreamWriter writer = new StreamWriter(filename))
      {
        writer.Write(data);
      }
    }

    #endregion 

    #region Fields

    private static Arguments arguments;

    private static ArgumentParser<Arguments> argumentParser;

    #endregion
  }
}
