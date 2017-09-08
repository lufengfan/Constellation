using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Shapes;

namespace αστερισμό
{
    public class ShapeCenterMultiValueConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new Exception($"{values.Length}, \r\n[\r\n    {string.Join(", \r\n    ", values.Select(value=>value.GetType()))}\r\n]");
            double left = (double)values[0];
            double top = (double)values[1];
            Shape shape = (Shape)values[2];
            ShapeCenterValueTypes valueType = (ShapeCenterValueTypes)parameter;
            
            double x = left + shape.Width / 2;
            double y = top + shape.Height / 2;
            switch (valueType)
            {
                case ShapeCenterValueTypes.X:
                    return x;
                case ShapeCenterValueTypes.Y:
                    return y;
                case ShapeCenterValueTypes.X | ShapeCenterValueTypes.Y:
                    return new Point(x, y);
                default:
                    throw new NotSupportedException();
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
