using System;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    internal class Program
    {
        private const string ProjectFilePath = "../../";

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string tableName = GetTableName();

            try
            {
                string[] data = GetData(tableName);
                JsonSchema schema = JsonSchema.GetFromJsonFile($"{ProjectFilePath}//Schemas//{tableName}.json");
                Table table = TableCreator.CreateTable(tableName, schema, data);

                table.OutputOnConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] GetData(string? fileName)
        {
            if (fileName != null)
            {
                string dataPath = $"{ProjectFilePath}//Data//{fileName}.csv";
                string schemaPath = $"{ProjectFilePath}//Schemas//{fileName}.json";
                return CsvReader.ReadFromCSV(dataPath, schemaPath);
            }
            else
            {
                throw new Exception("Вы не ввели название таблицы");
            }
        }

        private static string GetTableName()
        {
            Console.Write("Введите название таблицы: ");
            return Console.ReadLine() ?? throw new Exception();
        }
    }
}