using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClassWizard
{
    [ValueConversion(typeof(List<string>), typeof(string))]
    public class KeywordsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = value as List<string>;

            if (list == null || list.Count == 0)
            {
                return "";
            }

            return String.Join(", ", list) + " ";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(List<ArgumentObject>), typeof(string))]
    public class CountArgumentsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<ArgumentObject> list = value as List<ArgumentObject>;

            if (list == null || list.Count == 0)
            {
                return "void";
            }

            return String.Format("{0} {1}", list.Count, list.Count == 1 ? "arg" : "args");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InheritanceAndInterfacesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string result = " : ";

            List<string> list = new List<string>(values[1] as List<string>);

            if (values[0] != null && values[0] as string != "")
            {
                list.Insert(0, values[0] as string);
            }

            result += String.Join(", ", list);

            return result == " : " ? "" : result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
