using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.iOS;


using UIKit;
using NeatLibrary;
using NeatLibrary.iOS;
using Xamarin.Forms.Internals;

[assembly: ExportRenderer (typeof (NeatViewCell), typeof (NeatViewCellRenderer))]
namespace NeatLibrary.iOS
{
    [Preserve]
	public class NeatViewCellRenderer : ViewCellRenderer
	{
		static public void Initialize() { }
		public NeatViewCellRenderer () { }
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			try
			{
				var cell = base.GetCell(item,reusableCell, tv);
				var view = item as NeatViewCell;

				if (cell != null)
				{

					cell.BackgroundColor = UIColor.Clear;

					cell.SelectedBackgroundView = new UIView
					{
						BackgroundColor = view.SelectedBackgroundColor.ToUIColor()
					};
				}
				return cell;
			}
			catch(Exception exc)
			{
				return null;
			}
		}


	}
}

