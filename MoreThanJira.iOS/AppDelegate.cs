using Foundation;
using MoreThanJira.iOS.ViewControllers;
using UIKit;

namespace MoreThanJira.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        private new UIWindow _window;
        private UINavigationController _navigationController;

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            _window.MakeKeyAndVisible();

            var mainVC = new MainViewController();
            _window.RootViewController = mainVC;

            return true;
        }
    }
}

