using System;
using System.Windows;

namespace AdSoftwareSystems.Tracking.Mobile.Wpf
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;
    using Cirrious.MvvmCross.Wpf.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool _setupComplete;

        private void DoSetup()
        {
            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);

            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _setupComplete = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!_setupComplete)
                DoSetup();

            base.OnActivated(e);
        }
    }
}
