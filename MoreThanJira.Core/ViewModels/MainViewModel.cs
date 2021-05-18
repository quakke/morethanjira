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

        public MainViewModel(ITaskRepository taskRepository, IMvxNavigationService navigationService)
        {
            _taskRepository = taskRepository;
            _navigationService = navigationService;
        }

        public override async Task Initialize()
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
                    //Acr.UserDialogs.UserDialogs.Instance.Alert("Нет данных для отображения");
                }
            }
            catch (Exception ex)
            {
                //_logger.WarnException("Fail load artists: ", ex);
                //Acr.UserDialogs.UserDialogs.Instance.Alert("Проблемы при загрузке данных");
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
    }
}
