using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.iOS;


using UIKit;
using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;

[assembly: ExportRenderer (typeof (StandardViewCell), typeof (StandardViewCellRenderer))]
namespace FormStandard.iOS
{
    [Preserve]
	public class StandardViewCellRenderer : ViewCellRenderer
	{
		static public void Initialize() { }
		public StandardViewCellRenderer () { }
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			try
			{
				var cell = base.GetCell(item,reusableCell, tv);
				var view = item as StandardViewCell;

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

