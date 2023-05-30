using Newtonsoft.Json;

namespace DummyDB4engine
{
    public class Column
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }
    
        [JsonProperty(PropertyName = "не ")]
        public string Type { get; private set; }

        [JsonProperty(PropertyName = "isPrimary")]
        public bool IsPrimary { get; private set; }
    }
}