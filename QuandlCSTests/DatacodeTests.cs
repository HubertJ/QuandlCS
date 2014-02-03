using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuandlCS.Types;

namespace QuandlCSTests
{
  [TestClass]
  public class DatacodeTests
  {
    [TestMethod]
    public void Source_ValidCharacters_NoThrow()
    {
      var datacode = new Datacode()
      {
        Source = "PRAGUESE" // Shouldn't throw
      };
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Source_InvalidCharacters_Throw()
    {
      var datacode = new Datacode()
      {
        Source = "praguese" // Should throw
      };
    }

    [TestMethod]
    public void Code_ValidCharacters_NoThrow()
    {
      var datacode = new Datacode()
      {
        Code = "PX" // Shouldn't throw
      };
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Code_InvalidCharacters_Throw()
    {
      var datacode = new Datacode()
      {
        Code = "px" // Should throw
      };
    }
    
    [TestMethod]
    public void GetDatacode_Correct()
    {
      var datacode = new Datacode()
      {
        Source = "PRAGUESE",
        Code = "PX"
      };

      Assert.AreEqual("PRAGUESE/PX", datacode.ToDatacodeString('/'), "The unique code should be the Source and Code separated by a forward slash");
    }
  }
}
