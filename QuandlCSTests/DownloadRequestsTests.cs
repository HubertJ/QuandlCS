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
    public void ValidDatacodeSourceRequiredException()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode(string.Empty, "DW")
      };

      request.GetGETRequestString();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ValidDatacodeCodeRequiredException()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", string.Empty)
      };

      request.GetGETRequestString();
    }

    [TestMethod]
    public void ValidTruncationUsed()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Truncation = 1
      };

      var requestString = request.GetGETRequestString();
      Assert.IsTrue(requestString.Contains("&rows=1"));
    }

    [TestMethod]
    public void ZeroTruncationNotUsed()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Truncation = 0
      };

      var requestString = request.GetGETRequestString();
      Assert.IsFalse(requestString.Contains("&rows=0"));
    }

    [TestMethod]
    public void CSVFormatHeadersUsed()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Format = FileFormats.CSV
      };

      var requestString = request.GetGETRequestString();
      Assert.IsTrue(requestString.Contains("&exclude_headers="));
    }

    [TestMethod]
    public void NonCSVFormatHeadersNotUsed()
    {
      var request = new QuandlDownloadRequest()
      {
        Datacode = new Datacode("DW", "TEST"),
        Format = FileFormats.HTML
      };

      var requestString = request.GetGETRequestString();
      Assert.IsFalse(requestString.Contains("&exclude_headers="));
    }
  }
}
