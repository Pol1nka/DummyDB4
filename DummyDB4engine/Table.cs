using System;
using System.Collections.Generic;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    public class Table
    {
        public string Name { get; }
        public List<Row> Rows { get; }
        public JsonSchema Schema { get; }

        public Table(string name, JsonSchema schema)
        {
            Name = name;
            Rows = new List<Row>();
            Schema = schema;
        }

        public void OutputOnConsole()
        {
            Console.Clear();
            Console.WriteLine($"Таблица \"{Name}\"");
            foreach (var row in Rows)
            {
                Console.WriteLine(row);
            }

            Console.ReadKey();
        }
    }
}