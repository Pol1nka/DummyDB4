using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace DummyDB4engine
{
    public class JsonSchema
    {
        [JsonProperty(PropertyName = "name")] 
        public string Name { get; private set; } = null!;

        [JsonProperty(PropertyName = "columns")]
        public List<Column> Columns = new List<Column>();

        public static JsonSchema GetFromJsonFile(string path)
        {
            string fileText = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<JsonSchema>(fileText) ?? throw new Exception();
        }
    }
}