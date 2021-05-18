using Foundation;
using MoreThanJira.Core.ViewModels;
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

        private void Binding()
        {
            var set = this.CreateBindingSet<MainViewController, MainViewModel>();

            var source = new TaskTableSource(_taskTableView);
            set.Bind(source).To(vm => vm.Tasks);
            set.Bind(source).For(ds => ds.SelectionChangedCommand).To(vm => vm.SelectTaskCommand);
            _taskTableView.Source = source;
            _taskTableView.ReloadData();

            set.Bind(_addButton).To(vm => vm.AddTaskCommand);
            
            set.Apply();
        }
    }

    // TODO: вынести в отдельный файл
    public class TaskTableSource : MvxTableViewSource
    {
        private static readonly NSString TaskCellIdentifier = new NSString("TaskTableViewCell");

        public TaskTableSource(UITableView tableView) : base(tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("TaskTableViewCell", NSBundle.MainBundle), TaskCellIdentifier);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return TableView.DequeueReusableCell(TaskCellIdentifier, indexPath);
        }
    }
}

