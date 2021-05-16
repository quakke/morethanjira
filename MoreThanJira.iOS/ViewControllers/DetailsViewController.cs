using System;
using MoreThanJira.Api.Models;
using UIKit;

namespace MoreThanJira.iOS.ViewControllers
{
    public partial class DetailsViewController : UIViewController
    {
        private TaskEntity _task;
        private readonly bool isAddNewTask;

        public DetailsViewController(TaskEntity task) : base("DetailsViewController", null)
        {
            _task = task;

            isAddNewTask = (task == null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (isAddNewTask)
            {
                _creationDateLabel.Text = DateTime.Now.ToShortDateString();
                // TODO: сделать статус
                // пикер = дефолтное значение
                _titleTextField.Text = string.Empty;
                _descriptionTextView.Text = string.Empty;
            }
            else
            {
                _creationDateLabel.Text = _task.CreationDate.ToShortDateString();
                _titleTextField.Text = _task.Title;

                // TODO: сделать статус
                //_statusPickerView = _task.Status;

                _descriptionTextView.Text = _task.Description;
            }


            _saveButton.TouchUpInside += (args, sender) =>
            {
                if (isAddNewTask)
                {
                    // TODO: вынести метод в бэкэнд
                    // добавить новую запись в БД
                }
                else
                {
                    // TODO: вынести метод в бэкэнд
                    // редактировать существующую строчку
                }
            };
        }
    }
}

