using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDWRTBinReader.Logic
{
    public class Parameter
    {
        const string UNDEFINED = "UNDEFINED";

        public string Name { get; set; }
        public string Value { get; set; }

        public Parameter(string Name, string Value)
        {
            this.Name = Name;
            this.Value = string.IsNullOrWhiteSpace(Value) ? UNDEFINED : Value;
        }

        public Parameter(char[] Name, char[] Value)
            : this(new string(Name), new string(Value))
        {
        }
    }
}
