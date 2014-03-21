namespace AdSoftwareSystems.Tracking.Mobile.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using AdSoftwareSystems.Tracking.Common.Core.SocialMedia;
    using AdSoftwareSystems.Tracking.Mobile.Core.Services.SocialMedia;

    using Cirrious.MvvmCross.ViewModels;

    public class SocialMediaViewModel : MvxViewModel
    {
        private ISocialMediaService _socialMediaService;
        private List<SightingsMediaPost> _sightingsMediaPosts;
        private bool _isLoading;

        public SocialMediaViewModel(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;

            this.Update();
        }

        public List<SightingsMediaPost> SightingsMediaPosts
        {
            get { return _sightingsMediaPosts; }
            set { _sightingsMediaPosts = value; RaisePropertyChanged(() => SightingsMediaPosts); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private void Update()
        {
            IsLoading = true;
            _socialMediaService.GetLatestSightingPostsAsync(
                result =>
                {
                    IsLoading = false;
                    SightingsMediaPosts = result;
                },
                error =>
                {
                    IsLoading = false;
                });
        }

        public ICommand RefreshCommand
        {
            get { return new MvxCommand(Update); }
        }
    }
}
