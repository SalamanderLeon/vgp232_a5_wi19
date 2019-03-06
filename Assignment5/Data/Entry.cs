using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Data
{
    public class Entry
    {
        public object Key { get; set; }
        public object Value { get; set; }

        public Entry()
        {

        }

        public Entry(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
