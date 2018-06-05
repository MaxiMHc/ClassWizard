using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWizard
{
    public class ClassObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Keywords { get; set; }
        public string Inheritance { get; set; }
        public List<string> Interfaces { get; set; }
        public List<PropertyObject> Properties { get; set; }
        public List<MethodObject> Methods { get; set; }
    }

    public class MethodObject
    {
        public string Name { get; set; }
        public string AccessModifier { get; set; }
        public string ReturnType { get; set; }
        public List<string> Keywords { get; set; }
        public List<ArgumentObject> Arguments { get; set; }
    }

    public class ArgumentObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class PropertyObject
    {
        public string Name { get; set; }
        public string AccessModifier { get; set; }
        public string Type { get; set; }
        public List<string> Keywords { get; set; }
    }
}
