using System;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    public static class TableCreator
    {
        public static Table CreateTable(string tableName, JsonSchema schema, string[] data)
        {
            Table table = new Table(tableName, schema);
            for (var i = 0; i < data.Length; i++)
            {
                Row row = new Row();
                string[] rowElements = data[i].Split(';');
                for (var j = 0; j < rowElements.Length; j++)
                {
                    row.Items.Add(schema.Columns[j], GetData(rowElements[j], schema.Columns[j]));
                }
                table.Rows.Add(row); 
            }

            return table;;
        }

        private static object GetData(string value, Column column)
        {
            return column.Type switch
            {
                "int" => int.Parse(value),
                "float" => float.Parse(value),
                "bool" => bool.Parse(value),
                "dateTime" => DateTime.Parse(value),
                _ => value
            };
        }
    }
}