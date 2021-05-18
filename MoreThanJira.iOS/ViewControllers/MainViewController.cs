using Foundation;
using MoreThanJira.Core.ViewModels;
using MoreThanJira.iOS.Sources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MoreThanJira.iOS.ViewControllers
{
    public partial class MainViewController : MvxViewController<MainViewModel>
    {
        public MainViewController() : base("MainViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Список задачек";

            Binding();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<MainViewController, MainViewModel>();

            var tableSource = new TaskTableSource(ViewModel, _taskTableView);

            set.Bind(tableSource).To(vm => vm.Tasks);
            set.Bind(tableSource).For(ds => ds.SelectionChangedCommand).To(vm => vm.SelectTaskCommand);
            _taskTableView.Source = tableSource;
            _taskTableView.ReloadData();

            set.Bind(_addButton).To(vm => vm.AddTaskCommand);
            
            set.Apply();
        }
    }
}

