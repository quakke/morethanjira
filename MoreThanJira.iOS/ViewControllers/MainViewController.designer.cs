// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MoreThanJira.iOS.ViewControllers
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UIButton _addButton { get; set; }

		[Outlet]
		UIKit.UIView _emptyView { get; set; }

		[Outlet]
		UIKit.UITableView _taskTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_emptyView != null) {
				_emptyView.Dispose ();
				_emptyView = null;
			}

			if (_addButton != null) {
				_addButton.Dispose ();
				_addButton = null;
			}

			if (_taskTableView != null) {
				_taskTableView.Dispose ();
				_taskTableView = null;
			}
		}
	}
}
