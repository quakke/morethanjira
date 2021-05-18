using System;
using MoreThanJira.Api.Models;
using MvvmCross.Core.ViewModels;

namespace MoreThanJira.Core.ViewModels.Items
{
    public class ItemViewModel : MvxViewModel
    {
        public TaskEntity TaskEntity { get; }

        public ItemViewModel(TaskEntity taskModel)
        {
            TaskEntity = taskModel;
        }
    }
}
