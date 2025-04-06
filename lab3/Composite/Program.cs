namespace Composite;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        string[] headers = ["ID", "Name", "Age", "City"];
        string[][] tableData =
        [
            ["1", "John", "28", "New York"],
            ["2", "Mary", "34", "Los Angeles"],
            ["3", "Jane", "23", "Chicago"],
        ];
        var table = CreateTable(headers, tableData);
        table.ClassList.Add("table");
        Console.WriteLine(table.OuterHtml);
    }

    private static LightNodeElement CreateTable(string[] headers, string[][] tableData)
    {
        var table = CreateElement("table");
        table.AddChild(CreateHeader(headers));
        foreach (var rowData in tableData)
        {
            table.AddChild(CreateRow(rowData));
        }
        return table;
    }

    private static LightNodeElement CreateHeader(string[] headers)
    {
        var row = CreateElement("tr");
        foreach (var header in headers)
        {
            row.AddChild(CreateElement("th", header));
        }
        return row;
    }

    private static LightNodeElement CreateRow(string[] rowData)
    {
        var row = CreateElement("tr");
        foreach (var data in rowData)
        {
            row.AddChild(CreateElement("td", data));
        }
        return row;
    }

    private static LightNodeElement CreateElement(string tagName, string text)
    {
        var element = CreateElement(tagName);
        element.AddChild(new LightTextNode(text));
        return element;
    }
    
    private static LightNodeElement CreateElement(string tagName)
    {
        return new LightNodeElement(tagName, true, false);
    }
}