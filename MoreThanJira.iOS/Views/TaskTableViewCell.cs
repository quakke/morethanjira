using System;

using Foundation;
using MoreThanJira.Core.ViewModels.Items;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MoreThanJira.iOS.Views
{
    public partial class TaskTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TaskTableViewCell");
        public static readonly UINib Nib;

        static TaskTableViewCell()
        {
            Nib = UINib.FromName("TaskTableViewCell", NSBundle.MainBundle);
        }

        protected TaskTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => {
                BindControls();
            });
        }

        private void BindControls()
        {
            var set = this.CreateBindingSet<TaskTableViewCell, ItemViewModel>();

            set.Bind(_idLabel).To(vm => vm.TaskEntity.Id);
            set.Bind(_titleLabel).To(vm => vm.TaskEntity.Title);

            set.Apply();
        }
    }
}
