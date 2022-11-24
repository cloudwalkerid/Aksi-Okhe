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
    [ValueConversion(typeof(long), typeof(string))]
    class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long doubleType = 0;
            if(value == null)
            {
                return "";
            }
            else if (value is long)
            {
                doubleType = (long)value;
            }
            else
            {
                doubleType = long.Parse(value.ToString());
            }
            
            return doubleType.ToString("N0", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (strValue.Equals(""))
            {
                return null;
            }
            else
            {
                long resultDouble;
                if (long.TryParse(strValue.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, ""), out resultDouble))
                {
                    return resultDouble;
                }
                return DependencyProperty.UnsetValue;
            }
           
        }
    }
}
