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
        public string AccessModifier { get; set; }
        public List<string> Keywords { get; set; }
        public string Inheritance { get; set; }
        public List<string> Interfaces { get; set; }
        public List<PropertyObject> Properties { get; set; }
        public List<MethodObject> Methods { get; set; }

        public override string ToString()
        {
            return this.AccessModifier + " " + this.Name + " ";
        }
        public string ToFinalString()
        {
            //string result = String.Format("{0} {1} class {2}", AccessModifier, String.Join(" ", Keywords), Name);
            string result = AccessModifier;

            if (Keywords != null && Keywords.Any())
            {
                result += " " + String.Join(" ", Keywords);
            }

            result += " " + Name;

            if (Inheritance != null && Inheritance != "")
            {
                result += " : " + Inheritance;
            }

            if (Interfaces != null && Interfaces.Any())
            {
                if (Inheritance == null || Inheritance == "")
                {
                    result += " : ";
                }
                else
                {
                    result += ", ";
                }
                result += String.Join(", ", Interfaces);
            }

            result += "\n{\n";

            if (Properties != null && Properties.Any())
            {
                foreach (var item in Properties)
                {
                    result += "\t" + item.ToString() + " { get; set; }\n";
                }

                result += "\n";
            }

            if (Methods != null && Methods.Any())
            {
                foreach (var item in Methods)
                {
                    result += item.ToFinalString() + "\n";
                }

                result += "\n";
            }

            result += "}\n";

            return result;
        }
    }

    public class MethodObject
    {
        public string Name { get; set; }
        public string AccessModifier { get; set; }
        public string ReturnType { get; set; }
        public List<string> Keywords { get; set; }
        public List<ArgumentObject> Arguments { get; set; }

        public string ToFinalString()
        {
            //result = String.Format("\t{0} {1} {2} {3} ({4})", AccessModifier, String.Join(" ", Keywords), ReturnType, Name, String.Join(", ", Arguments));
            string result = "\t" + AccessModifier + " ";

            if (Keywords != null || !Keywords.Any())
            {
                result += String.Join(" ", Keywords) + " ";
            }

            result += ReturnType + " " + Name + "(";

            if (Arguments != null || !Arguments.Any())
            {
                result += String.Join(", ", Arguments);
            }

            result += ")\n\t{\n\n\t}";
            return result;
        }

        public string ToShortString()
        {
            if (Keywords == null || !Keywords.Any())
            {
                return String.Format("{0} {1} {2}", AccessModifier, ReturnType, Name);
            }

            return String.Format("{0} {1} {2} {3}", AccessModifier, String.Join(" ", Keywords), ReturnType, Name);
        }
    }

    public class ArgumentObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Keywords { get; set; }

        public override string ToString()
        {
            if (Keywords == null || !Keywords.Any())
            {
                return String.Format("{0} {1}", Type, Name);

            }

            return String.Format("{0} {1} {2}", String.Join(" ", Keywords), Type, Name);
        }
    }

    public class PropertyObject
    {
        public string Name { get; set; }
        public string AccessModifier { get; set; }
        public string Type { get; set; }
        public List<string> Keywords { get; set; }

        public override string ToString()
        {
            if (Keywords == null || !Keywords.Any())
            {
                return String.Format("{0} {1} {2}", AccessModifier, Type, Name);
            }

            return String.Format("{0} {1} {2} {3}", AccessModifier, String.Join(" ", Keywords), Type, Name);
        }
    }
}
