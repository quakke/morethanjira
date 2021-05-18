using MoreThanJira.Api.Repositories;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoreThanJira.Api
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.ConstructAndRegisterSingleton<ITaskRepository, TaskRepository>();
        }

    }
}
