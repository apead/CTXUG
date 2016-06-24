using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CrossPlatformDemo.Core.Services;
using CrossPlatformDemo.Core.Views;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Device = CrossPlatformDemo.Core.Models.Device;

namespace CrossPlatformDemo.Core.ViewModels
{
    public class DotNetDevicesViewModel
        : BaseViewModel
    {
        private AzureDevicesService _azureDevicesService;
        private ObservableCollection<Device> _devices;
        private Device _selectedItem;

        private DotNetDevicesView _view;

        private ICommand _refreshCommand;
        public ICommand RefreshCommand =>
         _refreshCommand ?? (_refreshCommand = new Command(async () => await GetDevicesAsync()));

        public ObservableCollection<Device> Devices
        {
            get { return _devices; }
            set { SetProperty(ref _devices, value); }
        }

        public Device SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public DotNetDevicesViewModel(DotNetDevicesView view)
        {
           
            _azureDevicesService = new AzureDevicesService();
            Devices = new ObservableCollection<Device>();

            _view = view;

            Task.Run(async () =>
            {
                await _azureDevicesService.InitializeAsync();
                
                await GetDevicesAsync();

            });
        }

        public async Task GetDevicesAsync()
        {
            try
            {
                LoadingMessage = "Loading...";
                IsLoading = true;

            await _azureDevicesService.SynchronizeAsync();
            var devices = await _azureDevicesService.GetDevicesAsync();

            Devices = new ObservableCollection<Device>(devices);

            }
            finally
            {
                IsLoading = false;
            }
        }

        public void OpenDevice()
        {
            if (SelectedItem != null)
            {
                _view.Navigation.PushAsync(new DotNetDeviceDetailView(SelectedItem));

            }
        }
    }
}
