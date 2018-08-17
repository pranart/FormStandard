using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using FormStandard;
using FormStandard.iOS;
using Xamarin.Forms.Internals;

[assembly:ExportRenderer(typeof(StandardListView), typeof(StandardListViewRenderer))]

namespace FormStandard.iOS
{
    [Preserve]
	public class StandardListViewRenderer : ListViewRenderer
	{
        static public void Initialize(){}
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			try
			{
				if (Control == null)
					return;

				var tableView = Control as UITableView;
				tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			}
			catch
			{
			}
		}
	}
}

