using System;
using MoreThanJira.Api.Models;
using MoreThanJira.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MoreThanJira.iOS.ViewControllers
{
    public partial class DetailsViewController : MvxViewController<DetailsViewModel>
    {
        public DetailsViewController() : base("DetailsViewController", null)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Binding();

            _descriptionTextView.Layer.BorderColor = UIColor.LightGray.CGColor;
            _descriptionTextView.Layer.BorderWidth = 1;
        }

        private void Binding()
        {
            var set = this.CreateBindingSet<DetailsViewController, DetailsViewModel>();

            set.Bind(_titleTextField).For("Text").To(vm => vm.Title);
            set.Bind(_descriptionTextView).For("Text").To(vm => vm.Description);
            set.Bind(_creationDateLabel).For("Text").To(vm => vm.CreatedDate);

            //TODO: сделать статус

            set.Bind(_saveButton).To(vm => vm.SaveTaskCommand);

            set.Apply();
        }
    }
}

