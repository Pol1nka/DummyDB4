using System;
using System.Linq;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    public static class JsonValidator
    {
        public static bool CheckBySchema(JsonSchema schema, string[] data)
    {
            bool checkedColumns = CheckColumnsNames(schema, data);
            bool flag = true;
            for (var i = 1; i < data.Length; i++)
            {
                flag = CheckTypes(data[i], schema, i);
                if (!flag)
                    return false;
            }

            return flag && checkedColumns;
    }

    private static bool CheckTypes(string input, JsonSchema schema, int raw)
    {
        string[] line = input.Split(';');
        for (var i = 0; i < line.Length; i++)
        {
            switch (schema.Columns[i].Type)
            {
                case "int":
                    if (!int.TryParse(line[i], out _))
                        throw new ArgumentException($"В строке {raw}, столбце {i + 1} : (элемент {line[i]}) ошибка ввода. Тип данных элемента не сходится со схемой.");
                    break;
                case "bool":
                    if (!bool.TryParse(line[i], out _))
                        throw new ArgumentException($"В строке {raw}, столбце {i + 1} : (элемент {line[i]}) ошибка ввода. Тип данных элемента не сходится со схемой.");
                    break;
                case "dateTime":
                    if (!DateTime.TryParse(line[i], out _))
                        throw new ArgumentException($"В строке {raw}, столбце {i + 1} : (элемент {line[i]}) ошибка ввода. Тип данных элемента не сходится со схемой.");
                    break;
                case "float":
                    if (!float.TryParse(line[i], out _))
                        throw new ArgumentException($"В строке {raw}, столбце {i + 1} : (элемент {line[i]}) ошибка ввода. Тип данных элемента не сходится со схемой.");
                    break;
            }

        }
        
        return true;
    }

        private static bool CheckColumnsNames(JsonSchema schema, string[] data)
        {
            string[] programInput = data[0].Split(';');
            if (programInput.Where((t, i) => t != schema.Columns[i].Name).Any())
            {
                throw new FormatException("Названия в файле введены неверно. Пожалуйста, исправьте ошибку и повторите попытку.");
            }

            return true;
        }
    }
}