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
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		UIKit.UILabel _creationDateLabel { get; set; }

		[Outlet]
		UIKit.UITextView _descriptionTextView { get; set; }

		[Outlet]
		UIKit.UILabel _idLabel { get; set; }

		[Outlet]
		UIKit.UIButton _saveButton { get; set; }

		[Outlet]
		UIKit.UIPickerView _statusPickerView { get; set; }

		[Outlet]
		UIKit.UITextField _titleTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_idLabel != null) {
				_idLabel.Dispose ();
				_idLabel = null;
			}

			if (_creationDateLabel != null) {
				_creationDateLabel.Dispose ();
				_creationDateLabel = null;
			}

			if (_titleTextField != null) {
				_titleTextField.Dispose ();
				_titleTextField = null;
			}

			if (_statusPickerView != null) {
				_statusPickerView.Dispose ();
				_statusPickerView = null;
			}

			if (_descriptionTextView != null) {
				_descriptionTextView.Dispose ();
				_descriptionTextView = null;
			}

			if (_saveButton != null) {
				_saveButton.Dispose ();
				_saveButton = null;
			}
		}
	}
}
