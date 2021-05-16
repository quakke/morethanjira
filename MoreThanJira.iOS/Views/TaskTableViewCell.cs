using System;

using Foundation;
using UIKit;

namespace MoreThanJira.iOS.Views
{
    public partial class TaskTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("TaskTableViewCell");
        public static readonly UINib Nib;

        static TaskTableViewCell()
        {
            Nib = UINib.FromName("TaskTableViewCell", NSBundle.MainBundle);
        }

        protected TaskTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
