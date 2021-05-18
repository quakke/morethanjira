using System;
using System.Collections.Generic;
using Foundation;
using MoreThanJira.Core.ViewModels;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MoreThanJira.iOS.Sources
{
    public class TaskTableSource : MvxTableViewSource
    {
        private static readonly NSString TaskCellIdentifier = new NSString("TaskTableViewCell");

        private readonly MainViewModel _viewModel;

        public TaskTableSource(MainViewModel viewModel, UITableView tableView) : base(tableView)
        {
            _viewModel = viewModel;

            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("TaskTableViewCell", NSBundle.MainBundle), TaskCellIdentifier);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return TableView.DequeueReusableCell(TaskCellIdentifier, indexPath);
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:

                    _viewModel.DeleteTaskCommand.Execute(_viewModel.Tasks[indexPath.Row]);

                    break;
                case UITableViewCellEditingStyle.None:

                    break;
            }
        }
    }
}
