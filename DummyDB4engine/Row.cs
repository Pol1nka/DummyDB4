using System.Collections.Generic;

namespace DummyDB4engine
{
    public class Row
    {
        public Dictionary<Column, object> Items { get; }

        public Row()
        {
            Items = new Dictionary<Column, object>();
        }

        public override string ToString()
        {
            return string.Join(" | ", Items.Values);
        }
    }
}