using System;
using Xamarin.Forms;

namespace FormStandard
{
	public class StandardPdfView : View
	{
		public StandardPdfView ()
		{
		}

		public static readonly BindableProperty PathProperty =
			BindableProperty.Create("Path",typeof(string),typeof(StandardPdfView),"");

		public string Path
		{
			get {return (string)base.GetValue (PathProperty);}
			set {base.SetValue (PathProperty, value);}
		}

	}
}

