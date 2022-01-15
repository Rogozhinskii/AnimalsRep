using AnimalPlanet.Core.Converters.Base;
using System;
using System.Globalization;
using System.Windows.Media;

namespace AnimalPlanet.Core.Converters
{
    /// <summary>
    /// Конвертер булевского значения в кисть 
    /// </summary>
    public class BoolToColorConverter : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null){
                bool result=(bool)value;
                if(result) return new SolidColorBrush(Colors.Red);
            }
            return new SolidColorBrush(Colors.Green);
            
        }
    }
}
