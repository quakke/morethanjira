using Acr.UserDialogs;
using MoreThanJira.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoreThanJira.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            new Api.App().Initialize();

            RegisterNavigationServiceAppStart<MainViewModel>();

            Mvx.RegisterSingleton(() => UserDialogs.Instance);
        }
    }
}
