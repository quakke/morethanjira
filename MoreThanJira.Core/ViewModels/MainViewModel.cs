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
        private readonly ITaskRepository _taskRepository;
        private readonly IMvxNavigationService _navigationService;

        public bool IsNoTasks => (Tasks == null || Tasks.Count == 0);

        private List<ItemViewModel> _tasks;
        public List<ItemViewModel> Tasks
        {
            get => _tasks;
            private set => SetProperty(ref _tasks, value);
        }

        #region Commands

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

        private void OnItemClick(ItemViewModel itemVm)
        {
            _navigationService.Navigate<DetailsViewModel, ItemViewModel>(itemVm);
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

        private void OnDeleteItemClick(ItemViewModel itemVm)
        {
            try
            {
                var result = _taskRepository.DeleteTaskAsync(itemVm.TaskEntity).Result;

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
