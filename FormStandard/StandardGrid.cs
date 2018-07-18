using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace FormStandard
{
    public class StandardGrid : Grid 
	{
		public StandardGrid ()
		{
			this.ColumnSpacing = 0;
			this.RowSpacing = 0;

			this.HorizontalOptions = LayoutOptions.Fill;
			this.VerticalOptions = LayoutOptions.Fill;

			this.BackgroundColor = Color.Transparent;
		}
		public int RowCount
		{
			get
			{
				if (RowDefinitions.Count == 0)
				{
					return 1;
				}
				return RowDefinitions.Count;
			}
		}
		public int ColumnCount
		{
			get
			{
				if (ColumnDefinitions.Count == 0)
				{
					return 1;
				}
				return ColumnDefinitions.Count;
			}
		}
		public virtual void ColumnAbsolute(double value)
		{
			this.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (value, GridUnitType.Absolute) });
		}
		public virtual void RowAbsolute(double value, bool isExtended = false)
		{
			this.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (value, GridUnitType.Absolute) });
		}
		public virtual void ColumnStar(double star)
		{

			this.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (star, GridUnitType.Star) });
		}
		public virtual void RowStar(double star, bool isExtended = false)
		{
			this.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (star, GridUnitType.Star) });
		}

		public void Add(Xamarin.Forms.View view,int column = 0,int row = 0,int columnSpan = 1,int rowSpan = 1)
		{
			this.Children.Add (view,column,column+columnSpan,row,row+rowSpan);
		}
	}
}

