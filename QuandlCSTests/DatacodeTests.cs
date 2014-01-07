using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuandlCS.Types;

namespace QuandlCSTests
{
  [TestClass]
  public class DatacodeTests
  {
    [TestMethod]
    public void DatacodeSourceValidCharacters()
    {
      var datacode = new Datacode();

      datacode.Source = "PRAGUESE"; // Shouldn't throw
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DatacodeSourceInvalidCharacters()
    {
      var datacode = new Datacode();

      datacode.Source = "praguese"; // Should throw
    }

    [TestMethod]
    public void DatasourceCodeValidCharacters()
    {
      var datacode = new Datacode();

      datacode.Code = "PX"; // Shouldn't throw
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DatasourceCodeInvalidCharacters()
    {
      var datacode = new Datacode();

      datacode.Code = "px"; // Should throw
    }
    
    [TestMethod]
    public void DatasourceUniqueCorrect()
    {
      var datacode = new Datacode();

      datacode.Source = "PRAGUESE";
      datacode.Code = "PX";

      Assert.AreEqual("PRAGUESE/PX", datacode.UniqueCode, "The unique code should be the Source and Code separated by a forward slash");
    }
  }
}
