using FormsMapsSample.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FormsMapsSample.Core.Views
{
    public partial class MapView : ContentPage
    {
        private MapViewModel _viewModel;
        public MapView()
        {
            _viewModel = new MapViewModel();

            InitializeComponent();

            LocationMap.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

            BindingContext = _viewModel;
        }
    }
}
