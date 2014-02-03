using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace QuandlCSTests
{
  [TestClass]
  public class DownloadRequestsTests
  {
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ToRequestString_InvalidDatacodeSource_ExceptionThrown()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode(string.Empty, "DW")
      };

      request.ToRequestString();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ToRequestString_InvalidDatacodeCode_ExceptionThrown()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", string.Empty)
      };

      request.ToRequestString();
    }

    [TestMethod]
    public void ToRequestString_ValidTruncation_UsedInRequestString()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Truncation = 1
      };

      var requestString = request.ToRequestString();
      Assert.IsTrue(requestString.Contains("&rows=1"));
    }

    [TestMethod]
    public void ToRequestString_ZeroTruncation_NotUsedInRequestString()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Truncation = 0
      };

      var requestString = request.ToRequestString();
      Assert.IsFalse(requestString.Contains("&rows=0"));
    }

    [TestMethod]
    public void ToRequestString_InvalidTruncation_ExceptionThrown()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Truncation = 0
      };

      var requestString = request.ToRequestString();
      Assert.IsFalse(requestString.Contains("&rows=0"));
    }

    [TestMethod]
    public void ToRequestString_CSVFormat_HeadersUsedInRequestString()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Format = FileFormats.CSV
      };

      var requestString = request.ToRequestString();
      Assert.IsTrue(requestString.Contains("&exclude_headers="));
    }

    [TestMethod]
    public void ToRequestString_NonCSVFormat_HeadersNotUsedInRequestString()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Format = FileFormats.HTML
      };

      var requestString = request.ToRequestString();
      Assert.IsFalse(requestString.Contains("&exclude_headers="));
    }

    [TestMethod]
    public void ToRequestString_StartDateBeforeEndDate_ExceptionNotThrown()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        StartDate = DateTime.Now.AddDays(-10), 
        EndDate = DateTime.Now.AddDays(10)     // End 20 days after start
      };

      var requestString = request.ToRequestString();
    }
  }
}
