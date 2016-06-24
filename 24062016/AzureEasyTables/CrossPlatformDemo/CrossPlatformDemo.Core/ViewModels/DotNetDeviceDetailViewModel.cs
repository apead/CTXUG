using CrossPlatformDemo.Core.Views;

namespace CrossPlatformDemo.Core.ViewModels
{
    public class DotNetDeviceDetailViewModel : BaseViewModel
    {
        private DotNetDeviceDetailView _view;
        private string _imageUrl;
        private string _deviceName;
        private string _description;
        private string _websiteUrl;
        private string _logoUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        public string DeviceName
        {
            get { return _deviceName; }
            set { SetProperty(ref _deviceName, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string WebsiteUrl
        {
            get { return _websiteUrl; }
            set { SetProperty(ref _websiteUrl, value); }
        }

        public string LogoUrl
        {
            get { return _logoUrl; }
            set { SetProperty(ref _logoUrl, value); }
        }


        public DotNetDeviceDetailViewModel(DotNetDeviceDetailView view, Models.Device selectedItem)
        {
            _view = view;

            if (selectedItem != null)
            {
                DeviceName = selectedItem.DeviceName;
                Description = selectedItem.Description;
                WebsiteUrl = selectedItem.WebsiteUrl;
                LogoUrl = selectedItem.LogoUrl;
                ImageUrl = selectedItem.ImageUrl;
                Title = DeviceName;
            }
        }

    }
}
