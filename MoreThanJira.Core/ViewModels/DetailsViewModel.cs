using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MoreThanJira.Api.Repositories;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoreThanJira.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel<ItemViewModel>
    {
        private ITaskRepository _taskRepository;

        #region Properties

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

        private string _createdDate;
        public string CreatedDate
        {
            get
            {
                return _createdDate;
            }
            private set
            {
                SetProperty(ref _createdDate, value);
            }
        }

        // TODO: сделать статус

        #endregion

        private IMvxAsyncCommand _saveTaskCommand;
        public IMvxAsyncCommand SaveTaskCommand
        {
            get
            {
                return _saveTaskCommand ?? (_saveTaskCommand = new MvxAsyncCommand(OnSaveButtonClicked));
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
                _title = TaskItem.TaskEntity.Title;
                _description = TaskItem.TaskEntity.Description;
                _createdDate = TaskItem.TaskEntity.CreationDate.ToString();
                // TODO: сделать статус
            }
        }

        private async Task OnSaveButtonClicked()
        { 
            var newTaskEntity = new Api.Models.TaskEntity()
            {
                Id = TaskItem?.TaskEntity?.Id ?? 0,
                Title = this.Title,
                Description = this.Description,
                CreationDate = TaskItem?.TaskEntity?.CreationDate ?? DateTime.Now
                // TODO: сделать статус
            };

            try
            {
                var result = await _taskRepository.SaveTaskAsync(newTaskEntity);

                if (result == 1)
                {
                    Mvx.Resolve<IUserDialogs>().Alert("Данные обновлены");
                }
                else
                {
                    Mvx.Resolve<IUserDialogs>().Alert("Данные не обновлены, но ничего не упало");
                }
            }
            catch (Exception ex)
            {
                Mvx.Resolve<IUserDialogs>().Alert("Что-то пошло не так, попробуйте позже");
            }
        }
    }
}
