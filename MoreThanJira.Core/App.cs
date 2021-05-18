using System;
using MoreThanJira.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace MoreThanJira.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            new Api.App().Initialize();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
