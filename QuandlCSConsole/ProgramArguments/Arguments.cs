using System;
using ProgramArgumentsCS.Attributes;
using ProgramArgumentsCS.Model;
using QuandlCS.Helpers;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSConsole.ProgramArguments
{
  [ProgramDetails("QuandlCSConsole", Publisher = "HubertJ")]
  [Help("A simple command line utility to request download data from Quandl and save to an output file")]
  public class Arguments
  {
    #region Construction

    /// <summary>
    /// Constructor for the arguments class to ensure objects are all created
    /// before the parsing begins
    /// </summary>
    public Arguments()
    {
      _filename = string.Empty;

      Download   = new DownloadVerb();
      Metadata   = new MetadataVerb();
      Search     = new SearchVerb();
      Favourites = new FavouritesVerb();
    }

    #endregion

    #region Interface

    /// <summary>
    /// Flag to set whether the application should output to the standard
    /// stream and request input from the user
    /// </summary>
    [ArgumentDetails("Quiet", "q", ArgumentRequirements.Optional, ArgumentType.Switch)]
    [Help("Switch to specify if the application should display output messages and require input from the user")]
    public bool Quiet
    {
      get;
      set;
    }

    /// <summary>
    /// The filename for the output file
    /// </summary>
    [ArgumentDetails("Filename", "filename", ArgumentRequirements.Mandatory, ArgumentType.Parameter)]
    [Help("The filename of the destination to output the results of the request", @"C:\QuandlCS\EURGBP.csv")]
    public string Filename
    {
      get { return _filename; }
      set { _filename = value; }
    }

    public IQuandlRequest Request
    {
      get
      {
        if (Download.Request != null)
        {
          return Download.Request;
        }
        else if (Metadata.Request != null)
        {
          return Metadata.Request;
        }
        else if (Search.Request != null)
        {
          return Search.Request;
        }
        else if (Favourites.Request != null)
        {
          return Favourites.Request;
        }
        else
        {
          return null;
        }
      }
    }

    [Verb("Download", "download")]
    [Help("Downloads data from Quandl and saves to the file")]
    public DownloadVerb Download
    {
      get;
      set;
    }

    [Verb("Metadata", "metadata")]
    [Help("Downloads metadata from Quandl and saves to the file")]
    public MetadataVerb Metadata
    {
      get;
      set;
    }

    [Verb("Favourites", "favourites")]
    [Help("Downloads users favourites from Quandl and saves to the file")]
    public FavouritesVerb Favourites
    {
      get;
      set;
    }
   
    [Verb("Search", "search")]
    [Help("Queries quandl for some search results and saves the returned data to the file")]
    public SearchVerb Search
    {
      get;
      set;
    }
    
    //[Verb("Multiset", "multiset")]
    //[Help("Downloads a multiset request from Quandl and saves the data to the file")]
    //public MultisetVerb Multiset
    //{
    //  get;
    //  set;
    //}
    
    #endregion

    #region Fields

    private string _filename;

    #endregion
  }
}
