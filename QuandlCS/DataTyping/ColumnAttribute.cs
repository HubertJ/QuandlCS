using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuandlCS.DataTyping
{
  /// <summary>
  /// Attribute for use on columns in datasets
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class ColumnAttribute : Attribute
  {
    /// <summary>
    /// Constructor for the column attribute
    /// </summary>
    /// <param name="name">The name of the column</param>
    public ColumnAttribute(string name)
    {
      Name = name;
    }

    /// <summary>
    /// The name of the column
    /// </summary>
    public string Name
    {
      get;
      private set;
    }
  }
}
