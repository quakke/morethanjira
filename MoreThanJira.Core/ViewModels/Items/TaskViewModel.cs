using System;
using MoreThanJira.Api.Models;

namespace MoreThanJira.Core.ViewModels.Items
{
    public class TaskViewModel
    {
        public TaskEntity TaskEntity { get; }

        public int Id => TaskEntity?.Id ?? -1;

        public string Title => TaskEntity?.Title ?? string.Empty;

        public string Description => TaskEntity?.Description ?? string.Empty;

        public DateTime CreationDateTime => TaskEntity?.CreationDate ?? new DateTime();

        // TODO: сделаьт статус
        //public status 

        public TaskViewModel(TaskEntity taskModel)
        {
            TaskEntity = taskModel;
        }
    }
}
