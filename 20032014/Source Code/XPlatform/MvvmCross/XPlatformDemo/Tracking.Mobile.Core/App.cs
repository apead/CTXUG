using Cirrious.CrossCore.IoC;

namespace AdSoftwareSystems.Tracking.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.SocialMediaViewModel>();
          //  RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}