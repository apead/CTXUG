using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FormsMapsSample.Core.Dto;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FormsMapsSample.Core.Behaviours
{
    public class BindableMapBehavior : BindableBehavior<Map>
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<BindableMapBehavior, IEnumerable<BindableLocation>>(
            p => p.ItemsSource, null, BindingMode.Default, null, ItemsSourceChanged);

        public IEnumerable<BindableLocation> ItemsSource
        {
            get { return (IEnumerable<BindableLocation>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void ItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var behavior = bindable as BindableMapBehavior;

            behavior?.SynchronizePins();
        }

        private void SynchronizePins()
        {
            var map = LinkedElement;
            for (int pinIndex = map.Pins.Count - 1; pinIndex >= 0; pinIndex--)
            {
                map.Pins[pinIndex].Clicked -= ClickedPinMapToCommand;
                map.Pins.RemoveAt(pinIndex);
            }

            var pins = ItemsSource.Select(source =>
            {
                var pin = new Pin
                {
                    Label = source.LocationTitle,
                    Address = source.LocationDescription,
                    Type = PinType.Place,
                    Position = new Position(source.Latitude, source.Longitude)
                };

                pin.Clicked += ClickedPinMapToCommand;
                return pin;
            }).ToArray();

            foreach (var pin in pins)
                map.Pins.Add(pin);

        }

        private void ClickedPinMapToCommand(object sender, EventArgs eventArgs)
        {
            var pin = sender as Pin;
            if (pin == null) return;
            var bindableLocation = ItemsSource.FirstOrDefault(x => x.LocationTitle == pin.Label);

            bindableLocation?.ActionCommand?.Execute(pin);
        }
    }
}
