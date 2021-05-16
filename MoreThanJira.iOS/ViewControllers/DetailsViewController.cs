using System;

using UIKit;

namespace MoreThanJira.iOS.ViewControllers
{
    public partial class DetailsViewController : UIViewController
    {
        public DetailsViewController() : base("DetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

