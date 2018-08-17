﻿using System;
using Xamarin.Forms;

namespace Validation.Forms.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return IsVisible(value);
        }

        internal static bool IsVisible(object value)
        {
            return ObjectVisibility.IsObjectVisible(value);
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}