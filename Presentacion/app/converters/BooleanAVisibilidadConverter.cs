using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OnBreakEventos.app.converters
{
    public class BooleanAVisibilidadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Revisamos dentro de las propiedades del objeto si acaso tiene la propiedad que buscamos

            if (value == null || value as bool? == false) // Revisamos contra un booleano nullable.
            {
                return Visibility.Hidden;
            }
            else
            {
                return Visibility.Visible;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
