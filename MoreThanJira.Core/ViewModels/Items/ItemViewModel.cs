using System;
using MoreThanJira.Api.Models;
using MvvmCross.Core.ViewModels;

namespace MoreThanJira.Core.ViewModels.Items
{
    public class ItemViewModel : MvxViewModel
    {
        public TaskEntity TaskEntity { get; }

        public int Id => TaskEntity?.Id ?? -1;

        public string Title => TaskEntity?.Title ?? string.Empty;

        public string Description => TaskEntity?.Description ?? string.Empty;

        // TODO сделать дату
        //public DateTime CreationDateTime => TaskEntity?.CreationDate ?? DateTime.Now;

        // TODO: сделаьт статус
        //public status 

        public ItemViewModel(TaskEntity taskModel)
        {
            TaskEntity = taskModel;
        }
    }
}
