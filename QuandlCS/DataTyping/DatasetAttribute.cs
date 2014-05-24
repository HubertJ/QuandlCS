using System;

namespace QuandlCS.DataTyping
{
  /// <summary>
  /// Attribute to apply to a class with the details of the dataset 
  /// to be downloaded
  /// </summary>
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
  public class DatasetAttribute : Attribute
  {
    /// <summary>
    /// Constructor for the dataset attribute class
    /// </summary>
    /// <param name="name">The name of the dataset</param>
    /// <param name="code">The code for the dataset</param>
    public DatasetAttribute(string name, string source, string code)
    {
      Name = name;
      Source = source;
      Code = code;
    }

    /// <summary>
    /// The name of the dataset
    /// </summary>
    public string Name
    {
      get;
      private set;
    }

    /// <summary>
    /// The source of the dataset
    /// </summary>
    public string Source
    {
      get;
      private set;
    }

    /// <summary>
    /// The code of the dataset
    /// </summary>
    public string Code
    {
      get;
      private set;
    }
  }
}
