using AnimalPlanet.Core.Converters.Base;
using System;
using System.Globalization;
using System.Text;

namespace AnimalPlanet.Core.Converters
{ 
    public class FullNameConverter : MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 0) return string.Empty;
            return $"Название {values[0]} Отряд:{values[1]}";           
        }
    }
}
