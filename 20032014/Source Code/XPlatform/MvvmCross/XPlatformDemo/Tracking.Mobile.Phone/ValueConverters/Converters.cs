namespace AdSoftwareSystems.Tracking.Mobile.Phone.ValueConverters
{
    using AdSoftwareSystems.Tracking.Mobile.Core.ValueConverters;

    using Cirrious.CrossCore.WindowsPhone.Converters;
    using Cirrious.MvvmCross.Plugins.Visibility;

    public class NativeVisibilityConverter : MvxNativeValueConverter<MvxVisibilityValueConverter>
    {
    }

    public class NativeInvertedVisibilityConverter : MvxNativeValueConverter<MvxInvertedVisibilityValueConverter>
    {
    }

    public class NativeInverseBoolConverter : MvxNativeValueConverter<InverseBoolValueConverter>
    {
    }
}
