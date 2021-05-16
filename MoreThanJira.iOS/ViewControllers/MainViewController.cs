using System;

using UIKit;

namespace MoreThanJira.iOS.ViewControllers
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController() : base("MainViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            _addButton.TouchUpInside += (sender, e) =>
            {
                // TODO: в Core создать метод для открывания следующего экрана
                var detailsVC = new DetailsViewController(null);
                this.NavigationController.PushViewController(detailsVC, true);
            };
        }
    }
}

