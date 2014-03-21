using System;

namespace AdSoftwareSystems.Tracking.Mobile.Phone.Views
{
    using AdSoftwareSystems.Tracking.Mobile.Core.ViewModels;

    using Cirrious.MvvmCross.WindowsPhone.Views;

    public partial class SocialMediaView : MvxPhonePage
    {
        public SocialMediaView()
        {
            InitializeComponent();
        }

        private SocialMediaViewModel socialMediaViewModel
        {
            get { return ((SocialMediaViewModel)ViewModel); }
        }


        private void RefreshButton_OnClick(object sender, EventArgs e)
        {
            socialMediaViewModel.RefreshCommand.Execute(null);
        }
    }
}