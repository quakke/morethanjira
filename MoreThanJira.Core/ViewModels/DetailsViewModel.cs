using System;
using MoreThanJira.Api.Repositories;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Core.ViewModels;

namespace MoreThanJira.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel<ItemViewModel>
    {
        private ITaskRepository _taskRepository;

        private ItemViewModel _taskItem;
        public ItemViewModel TaskItem
        {
            get
            {
                return _taskItem;
            }
            private set
            {
                SetProperty(ref _taskItem, value);
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                SetProperty(ref _description, value);
            }
        }

        // TODO: сделать статус

        private IMvxCommand _saveTaskCommand;
        public IMvxCommand SaveTaskCommand
        {
            get
            {
                return _saveTaskCommand ?? (_saveTaskCommand = new MvxCommand(OnSaveButtonClicked));
            }
        }

        public DetailsViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override void Prepare(ItemViewModel parameter)
        {
            base.Prepare();

            TaskItem = parameter;

            if (TaskItem != null)
            {
                _title = TaskItem.Title;
                _description = TaskItem.Description;
                // TODO: сделать дату
                // TODO: сделать статус
            }
        }

        private void OnSaveButtonClicked()
        { 
            var newTaskEntity = new Api.Models.TaskEntity()
            {
                Id = TaskItem?.TaskEntity?.Id ?? 0,
                Title = this.Title,
                Description = this.Description,
                CreationDate = TaskItem?.TaskEntity?.CreationDate ?? DateTime.Now
                // TODO: сделать статус
            };

            _taskRepository.SaveTaskAsync(newTaskEntity);
        }
    }
}
