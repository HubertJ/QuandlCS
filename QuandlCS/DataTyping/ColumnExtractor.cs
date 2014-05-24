using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace QuandlCS.DataTyping
{
  public class ColumnExtractor<T> where T : new()
  {
    #region Interface

    public ColumnExtractor(string xml)
    {
      _xmlDocument = XDocument.Parse(xml);
    }

    public IEnumerable<T> GetData()
    {
      if (_datapointsExtracted == false)
      {
        Prepare();

        ExtractData();
      }
      return _datapoints;
    }

    #endregion

    #region Implementation

    private void ExtractData()
    {
      foreach (XElement element in _dataElements)
      {
        T data = ExtractColumnData(element);
        _datapoints.Add(data);
      }
      _datapointsExtracted = true;
    }

    private void Prepare()
    {
      SetColumnPositionsFromData();

      SetDatatypeProperties();

      SetDatapointElements();

      CreateEmptyDatapointList();
    }

    private void CreateEmptyDatapointList()
    {
      _datapoints = new List<T>(_dataElements.Count());
    }

    private T ExtractColumnData(XElement parentElement)
    {
      T instance = new T();

      int columnPosition = 0;
      IEnumerable<XElement> elements = GetColumnDataElements(parentElement);
      foreach (var element in elements)
      {
        if (CheckColumnValid(columnPosition, element) == true)
        {
          SetColumnInInstance(instance, columnPosition, element);
        }
        columnPosition++;
      }
      return instance;
    }

    private void SetColumnInInstance(T instance, int columnPosition, XElement element)
    {
      PropertyInfo property = _datatypeProperties[columnPosition];
      property.SetValue(instance, Convert.ChangeType(element.Value, property.PropertyType), null);
    }

    private bool CheckColumnValid(int columnPosition, XElement element)
    {
      return _datatypeProperties.ContainsKey(columnPosition)
          && string.IsNullOrWhiteSpace(element.Value) == false;
    }

    private IEnumerable<XElement> GetColumnDataElements(XElement parentElement)
    {
      IEnumerable<XElement> elements = parentElement.Elements("datum");
      return elements;
    }

    private void SetDatapointElements()
    {
      _dataElements = _xmlDocument.Root.Elements("data").Elements("datum");
    }

    private void SetColumnPositionsFromData()
    {
      IEnumerable<XElement> elements = GetColumnDetailElements();
      ReadColumnDetails(elements);
    }

    private IEnumerable<XElement> GetColumnDetailElements()
    {
      IEnumerable<XElement> elements = _xmlDocument.Root.Elements("column-names").Elements("column-name");
      return elements;
    }

    private void ReadColumnDetails(IEnumerable<XElement> elements)
    {
      _columnPositions = new Dictionary<int, string>();

      int columnPosition = 0;
      foreach (var element in elements)
      {
        _columnPositions.Add(columnPosition, element.Value);
        columnPosition++;
      }
    }

    private void SetDatatypeProperties()
    {
      _datatypeProperties = new Dictionary<int, PropertyInfo>();

      var properties = typeof(T).GetProperties();
      foreach (var property in properties)
      {
        var columnDetails = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute), false);
        if (columnDetails != null)
        {
          int column = _columnPositions.FirstOrDefault(col => col.Value.Equals(columnDetails.Name))
                                       .Key;

          _datatypeProperties.Add(column, property);
        }
      }
    }

    private XDocument _xmlDocument;

    private Dictionary<int, string> _columnPositions;

    private Dictionary<int, PropertyInfo> _datatypeProperties;

    private IEnumerable<XElement> _dataElements;

    private List<T> _datapoints;

    private bool _datapointsExtracted = false;

    #endregion
  }
}
