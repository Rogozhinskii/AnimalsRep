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
        /// <summary>
        /// если true, то красная кисть, иначе зеленая. На вход подается булевское значение описывающие вымирает ли вид животного
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
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
