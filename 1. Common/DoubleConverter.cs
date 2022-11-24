using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Akhi_Okhee._1._Common
{
    [ValueConversion(typeof(double), typeof(string))]
    class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            double doubleType = 0;
            if (value is double)
            {
                Console.WriteLine("value is double => " + value.ToString());
                doubleType = (double)value;
            }
            else if (value == null)
            {
                return "";
            }
            else
            {
                Console.WriteLine("value is string => "+(string)value);
                doubleType = double.Parse((string)value);
            }

            return doubleType.ToString("N", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Conver Back "+ value);
            string strValue = value as string;
            if (strValue.Equals(""))
            {
                return null;
            }
            else
            {
                
                double resultDouble;
                if (double.TryParse(strValue.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, ""), out resultDouble))
                {
                    return resultDouble;
                }
               /* Console.WriteLine("Unlink");*/
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
