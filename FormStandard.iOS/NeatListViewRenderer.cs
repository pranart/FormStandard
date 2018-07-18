using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using NeatLibrary;
using NeatLibrary.iOS;
using Xamarin.Forms.Internals;

[assembly:ExportRenderer(typeof(NeatListView), typeof(NeatListViewRenderer))]

namespace NeatLibrary.iOS
{
    [Preserve]
	public class NeatListViewRenderer : ListViewRenderer
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

