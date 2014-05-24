using System;
using System.Collections.Generic;
using QuandlCS.DataTyping;

namespace QuandlCSConsole
{
  [Dataset("Gold", "LBMA", "GOLD")]
  public class Gold
  {
    [Column("Date")]
    public DateTime Date
    {
      get;
      set;
    }

    [Column("USD (AM)")]
    public double USDMorning
    {
      get;
      set;
    }

    [Column("GBP (PM)")]
    public double GBPAfternoon
    {
      get;
      set;
    }
  }

  [Dataset("Bananas", "ODA", "PBANSOP_USD")]
  public class Bananas
  {
    [Column("Date")]
    public DateTime Date
    {
      get;
      set;
    }

    [Column("Value")]
    public double Value
    {
      get;
      set;
    }    
  }

  [Dataset("USD vs NZD", "QUANDL", "USDNZD")]
  public class USDNZD
  {
    [Column("Date")]
    public DateTime Date
    {
      get;
      set;
    }

    [Column("Rate")]
    public double Rate
    {
      get;
      set;
    }

    [Column("High (est)")]
    public double High
    {
      get;
      set;
    }

    [Column("Low (est)")]
    public double Low
    {
      get;
      set;
    }
  }

  
  class Program
  {
    private static void Main(string[] args)
    {
      IEnumerable<Gold> goldData = Test<Gold>();
      IEnumerable<Bananas> bananaData = Test<Bananas>();
      IEnumerable<USDNZD> usdnzdData = Test<USDNZD>();

      Console.ReadKey(true);
    }

    private static IEnumerable<T> Test<T>() where T : new()
    {
      DownloadOptions options = new DownloadOptions()
      {
        Start = new DateTime(2005, 01, 01),
        End = new DateTime(2010, 12, 31)
      };

      DatasetDownloader<T> downloader = new DatasetDownloader<T>();
      IEnumerable<T> data = downloader.Download(options);
      return data;
    }
  }
}
