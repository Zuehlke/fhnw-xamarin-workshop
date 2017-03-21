using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Mvx.Exercises.Converters
{
    public class GradeAchievedToTextConverter : MvxValueConverter<decimal, string>
    {
        protected override string Convert(decimal value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value < 4)
                return $"{value:F} ... Could be better";

            return value < 5 ? $"{value:F} (Good)" : $"{value:F} awe-to-the-some!!";
        }
    }
}