using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    public static class CsvReader
    {
        public static string[] ReadFromCSV(string dataFilePath, string jsonSchemaFilePath)
        {
            string[] csv = File.ReadAllLines(dataFilePath);
            JsonSchema schema = JsonSchema.GetFromJsonFile(jsonSchemaFilePath);

            try
            {
                if (JsonValidator.CheckBySchema(schema, csv))
                    return csv.Skip(1).ToArray();
                else
                    return csv;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.Write("Ошибка: ");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return null;
        }
    }
}