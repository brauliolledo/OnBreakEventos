using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OnBreakEventos.app.converters
{
    public class ClaseTienePropiedadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Revisamos dentro de las propiedades del objeto si acaso tiene la propiedad que buscamos

            if(value == null)
            {
                return false;
            }

            return value.GetType().GetProperties().
                Select(p => p.Name).
                Any(pn => pn.Equals(parameter as string));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
