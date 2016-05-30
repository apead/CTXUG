using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using FormsMapsSample.Core.Dto;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FormsMapsSample.Core.ViewModels
{
    public class MapViewModel
    {
        public ObservableCollection<BindableLocation> Locations { get; set; }

        public ICommand PinCommand;

        public MapViewModel()
        {
            var locations = new List<BindableLocation>();
            var location = new BindableLocation
            {
                LocationTitle = "Disney Land",
                LocationDescription = "Disney Land",
                Latitude = 33.8121,
                Longitude = -117.9190,
                ActionCommand = new Command(PinSelected)
            };
            locations.Add(location);

            location = new BindableLocation
            {
                LocationTitle = "Disney World",
                LocationDescription = "Disney World",
                Latitude = 28.418749,
                Longitude = -81.581211,
                ActionCommand = new Command(PinSelected)
            };

            locations.Add(location);

            location = new BindableLocation
            {
                LocationTitle = "Disney Paris",
                LocationDescription = "Disney Paris",
                Latitude = 48.872552,
                Longitude = 2.776741,
                ActionCommand = new Command(PinSelected)

            };

            locations.Add(location);

            location = new BindableLocation
            {
                LocationTitle = "Disney Hong Kong",
                LocationDescription = "Disney Hong Kong",
                Latitude = 22.313987,
                Longitude = 114.041182,
                ActionCommand = new Command(PinSelected)
            };

            locations.Add(location);

            Locations = new ObservableCollection<BindableLocation>(locations);
        }

        public void PinSelected(object param)
        {
            var pin = param as Pin;

            if (pin != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UserDialogs.Instance.Alert(pin.Label);
                });
            }
        }
    }
}
