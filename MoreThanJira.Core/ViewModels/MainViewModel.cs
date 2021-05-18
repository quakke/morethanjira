using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using MoreThanJira.Api.Repositories;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoreThanJira.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private ITaskRepository _taskRepository;
        private IMvxNavigationService _navigationService;

        public bool IsNoTasks => (Tasks == null || Tasks.Count == 0);

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

        #region Commands

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

        #endregion

        public MainViewModel(ITaskRepository taskRepository, IMvxNavigationService navigationService)
        {
            _taskRepository = taskRepository;
            _navigationService = navigationService;
        }

        public override void ViewAppearing()
        {
            UpdateTasks();

            base.ViewAppearing();
        }

        #region CommandsActions

        private void OnItemClick(ItemViewModel itemVM)
        {
            _navigationService.Navigate<DetailsViewModel, ItemViewModel>(itemVM);
        }

        private void OnAddItemClick()
        {
            _navigationService.Navigate<DetailsViewModel>();
        }

        private void UpdateTasks()
        {
            Tasks = new List<ItemViewModel>();
            try
            {
                var tasks = _taskRepository.GetTasksAsync().Result;
                if (tasks != null)
                {
                    var tasksModel = tasks.Select(task => new ItemViewModel(task)).ToList();
                    Tasks = new List<ItemViewModel>(tasksModel);
                }
            }
            catch (Exception ex)
            {
                Mvx.Resolve<IUserDialogs>().Alert("Что-то пошло не так, попробуйте позже");
            }
        }

        private void OnDeleteItemClick(ItemViewModel itemVM)
        {
            try
            {
                var result = _taskRepository.DeleteTaskAsync(itemVM.TaskEntity).Result;

                if (result == 1)
                {
                    Mvx.Resolve<IUserDialogs>().Alert("Удалили успешно");
                    UpdateTasks();
                }
                else
                {
                    Mvx.Resolve<IUserDialogs>().Alert("Не удалилось, но не упало");
                }
            }
            catch (Exception ex)
            {
                Mvx.Resolve<IUserDialogs>().Alert("Что-то пошло не так, попробуйте позже");
            }
        }

        #endregion
    }
}
