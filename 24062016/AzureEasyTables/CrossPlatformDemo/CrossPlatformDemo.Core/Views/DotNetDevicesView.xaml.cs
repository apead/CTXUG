using CrossPlatformDemo.Core.ViewModels;
using Xamarin.Forms;

namespace CrossPlatformDemo.Core.Views
{
    public partial class DotNetDevicesView : ContentPage
    {
        private DotNetDevicesViewModel _dotNetDevicesViewModel;

        public DotNetDevicesView()
        {
            InitializeComponent();

            _dotNetDevicesViewModel = new DotNetDevicesViewModel(this);
            BindingContext = _dotNetDevicesViewModel;
           

            if (Device.OS != TargetPlatform.iOS && Device.OS != TargetPlatform.Android)
            {
                ToolbarItems.Add(new ToolbarItem
                {
                    Text = "Refresh",
                    Command = _dotNetDevicesViewModel.RefreshCommand
                });
            }
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                DevicesListView.ItemTapped -= ItemTapped;
                if (sender is ListView)
                {
                   
                    if (_dotNetDevicesViewModel != null)
                    {
                        _dotNetDevicesViewModel.SelectedItem = e.Item as Models.Device;
                        _dotNetDevicesViewModel.OpenDevice();
                        DevicesListView.SelectedItem = null;
                    }
                }
            }
            finally
            {
                DevicesListView.ItemTapped += ItemTapped;
            }
        }
    }
}
