using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreThanJira.Api.Repositories;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MoreThanJira.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private ITaskRepository _taskRepository;
        private IMvxNavigationService _navigationService;

        private List<ItemViewModel> _tasks;
        public List<ItemViewModel> Tasks
        {
            get
            {
                return _tasks;
            }
            private set
            {
                SetProperty(ref _tasks, value);
            }
        }

        private IMvxAsyncCommand _refreshCommand;
        public IMvxAsyncCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(Initialize));
            }
        }

        private IMvxCommand _selectTaskCommand;
        public IMvxCommand SelectTaskCommand
        {
            get
            {
                return _selectTaskCommand ?? (_selectTaskCommand = new MvxCommand<ItemViewModel>(OnItemClick));
            }
        }

        private IMvxCommand _addTaskCommand;
        public IMvxCommand AddTaskCommand
        {
            get
            {
                return _addTaskCommand ?? (_addTaskCommand = new MvxCommand(OnAddItemClick));
            }
        }

        private IMvxCommand _deleteTaskCommand;
        public IMvxCommand DeleteTaskCommand
        {
            get
            {
                return _deleteTaskCommand ?? (_deleteTaskCommand = new MvxCommand<ItemViewModel>(OnDeleteItemClick));
            }
        }

        public MainViewModel(ITaskRepository taskRepository, IMvxNavigationService navigationService)
        {
            _taskRepository = taskRepository;
            _navigationService = navigationService;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            _ = UpdateTasks();
        }

        private async Task UpdateTasks()
        {
            Tasks = new List<ItemViewModel>();
            try
            {
                var tasks = await _taskRepository.GetTasksAsync();
                if (tasks != null)
                {
                    var tasksModel = tasks.Select(task => new ItemViewModel(task)).ToList();
                    Tasks = new List<ItemViewModel>(tasksModel);
                }
                else
                {
                    // TODO сообщ "Нет данных для отображения"
                }
            }
            catch (Exception ex)
            {
                // TODO: сообщ "Че-то упало ", ex
            }
        }

        private void OnItemClick(ItemViewModel itemVM)
        {
            _navigationService.Navigate<DetailsViewModel, ItemViewModel>(itemVM);
        }

        private void OnAddItemClick()
        {
            _navigationService.Navigate<DetailsViewModel>();
        }

        private void OnDeleteItemClick(ItemViewModel itemVM)
        {
            try
            {
                var result = _taskRepository.DeleteTaskAsync(itemVM.TaskEntity).Result;

                if (result == 1)
                {
                    // TODO сообщ "Все ок"
                    _ = UpdateTasks();
                }
                else
                {
                    // TODO сообщ "Че-то не ок"
                }
            }
            catch (Exception ex)
            {
                // TODO: сообщ "Че-то упало: ", ex
            }
        }
    }
}
