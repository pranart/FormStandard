using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace FormStandard
{
	public class FlexGrid : StandardGrid
	{
//		public double Height { get; set; } = 0.0;
//		public double Width { get; set; } = 0.0;

		protected double ScaleX { get; set; } = 1.0;
		protected double ScaleY { get; set; } = 1.0;

		protected List<double> ListColumn { get; set; } = new List<double>();
		protected List<double> ListRow { get; set; } = new List<double>();
		protected List<double> ListPerPage { get; set; } = new List<double>();

		public FlexGrid () : base()
		{
		}
		public override void ColumnStar(double star)
		{
			ListColumn.Add (star);
		}
		public override void RowStar (double star, bool isExtended = false)
		{
			ListRow.Add (star);
			if(!isExtended)
			{
				ListPerPage.Add(star);
			}
		}
		protected double TotalColumnValue()
		{
			double sum = 0.0;
			if (ListColumn.Count == 0) 
			{
				sum = 1.0;
			} 
			else
			{
                foreach(var columnStar in ListColumn)
                {
                    sum += columnStar;
                }
			}
			return sum;
		}
		protected double TotalRowPerPageValue()
		{
			double sum = 0.0;
			if (ListRow.Count == 0) 
			{
				sum = 1.0;
			} 
			else
			{
                foreach (var rowStar in ListPerPage)
                {
                    sum += rowStar;
                }
			}
			return sum;
		}
		public void Finalize(double percent)
		{
			//CalculateScale (App.Width,(int)(App.Height*percent));
			ReApplyDefinitions ();
		}
		protected void CalculateScale(int resolutionX,int resolutionY)
		{
			if(resolutionX == 0 || resolutionY == 0)
			{
				throw new InvalidOperationException ();
			}
			ScaleX = (double)resolutionX / TotalColumnValue ();
			ScaleY = (double)resolutionY / TotalRowPerPageValue ();
		}
		protected void ReApplyDefinitions()
		{
			ReApplyRows ();
			ReApplyColumns ();
		}
		protected void ReApplyRows()
		{
			double sumHeight = 0.0;
			foreach(double star in ListRow)
			{
				double pixelsRow = star * ScaleY;
				RowDefinitions.Add (new RowDefinition{ Height = new GridLength (pixelsRow, GridUnitType.Absolute) });
				sumHeight += pixelsRow;
			}
			//Height = App.Height;
		}
		protected void ReApplyColumns()
		{
			foreach(double star in ListColumn)
			{
				ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (star * ScaleX, GridUnitType.Absolute) });
			}
			//Width = App.Width;
		}

	}
}

