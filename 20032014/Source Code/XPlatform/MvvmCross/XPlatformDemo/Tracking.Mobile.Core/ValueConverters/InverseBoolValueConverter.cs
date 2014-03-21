﻿namespace AdSoftwareSystems.Tracking.Mobile.Core.ValueConverters
{
    using System;

    using Cirrious.CrossCore.Converters;

    public class InverseBoolValueConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value;
        }
    }
}
