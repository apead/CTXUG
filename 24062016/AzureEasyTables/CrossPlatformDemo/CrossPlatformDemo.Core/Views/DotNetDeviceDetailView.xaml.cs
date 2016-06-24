using CrossPlatformDemo.Core.ViewModels;
using Xamarin.Forms;

namespace CrossPlatformDemo.Core.Views
{
    public partial class DotNetDeviceDetailView : ContentPage
    {
        private DotNetDeviceDetailViewModel _dotNetDeviceDetailViewModel;
        public DotNetDeviceDetailView(Models.Device selectedItem)
        {
            InitializeComponent();

            _dotNetDeviceDetailViewModel = new DotNetDeviceDetailViewModel(this, selectedItem);
            BindingContext = _dotNetDeviceDetailViewModel;
        }
    }
}
