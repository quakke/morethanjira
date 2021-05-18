// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MoreThanJira.iOS.Views
{
	[Register ("TaskTableViewCell")]
	partial class TaskTableViewCell
	{
		[Outlet]
		UIKit.UILabel _idLabel { get; set; }

		[Outlet]
		UIKit.UILabel _titleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_idLabel != null) {
				_idLabel.Dispose ();
				_idLabel = null;
			}

			if (_titleLabel != null) {
				_titleLabel.Dispose ();
				_titleLabel = null;
			}
		}
	}
}
