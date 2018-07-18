using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FormStandard
{
	public class GridView : Layout<View>
	{
		public static readonly new BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(GridView), null, BindingMode.OneWay, null,(bindable, oldValue, newValue) => 
		{
			var view = (GridView)bindable;
            view.ReCreateChildrens();	
		}, null, null, null);

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}
        
        
		public static readonly BindableProperty ItemTemplateProperty 
		= BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(GridView),new DataTemplate(), BindingMode.OneWay, null
		                                                                                       
		                          ,(bindable, oldValue, newValue) => 
		{
			var view = (GridView)bindable;
            view.ReCreateChildrens();
		}, propertyChanging: null, coerceValue: null, defaultValueCreator: null);

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}


		public int MaxItemsPerRow { get; set; }
		public int ItemHeight { get; set; }
		public double RowSpacing { get; set; }
		public double ColumnSpacing { get; set; }


		public GridView()
		{
			//BackgroundColor = Color.Red;
			var panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += (s, e) =>
			{
				if (PanCommand.CanExecute(e))
				{
					PanCommand.Execute(e);
				}
			};
			this.GestureRecognizers.Add(panGesture);
			MessagingCenter.Subscribe<object>(this, "RefreshGridView",(obj) => 
			{
				ReCreateChildrens();
			});
		}

		public static readonly BindableProperty PanCommandProperty =
			BindableProperty.Create(nameof(PanCommandProperty), typeof(Command), typeof(GridView), new Command(() => { }), BindingMode.Default);
		public Command PanCommand
		{
			get { return (Command)GetValue(PanCommandProperty); }
			set { SetValue(PanCommandProperty, value); }
		}
		private void ReCreateChildrens()
		{
			if (ItemsSource == null || ItemTemplate == null)
				return;

			Children.Clear();
			foreach (var item in ItemsSource)
			{
				var view = ItemTemplate.CreateContent() as View;
				view.BindingContext = item;
				Children.Add(view);
			}
			//int count = 0;
			//foreach(var each in ItemsSource)
			//{
			//	if(count >= Children.Count)
			//	{
			//		var view = ItemTemplate.CreateContent() as View;
			//		view.BindingContext = each;
			//		Children.Add(view);
			//	}
			//	count++;
			//}
		}


		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			var colWidth = width / MaxItemsPerRow;
			for (int i = 0; i < Children.Count; i++)
			{
				var child = Children[i];
				if (!child.IsVisible)
					continue;

				var virtualColumn = i % MaxItemsPerRow;
				var virtualRow = i / MaxItemsPerRow;

				var rowSpacing = (virtualRow != 0) ? RowSpacing : 0;
				var colSpacing = (virtualColumn != 0) ? ColumnSpacing : 0;

				var childX = x + (colWidth + colSpacing) * virtualColumn;
				var childY = y + (ItemHeight + rowSpacing) * virtualRow;
				LayoutChildIntoBoundingRegion(child, new Rectangle(childX, childY, colWidth, ItemHeight));
			}
		}

#pragma warning disable CS0672 // Member overrides obsolete member
        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
#pragma warning restore CS0672 // Member overrides obsolete member
        {

			// Check our cache for existing results
			SizeRequest cachedResult;
			var constraintSize = new Size(widthConstraint, heightConstraint);
			if (_measureCache.TryGetValue(constraintSize, out cachedResult))
			{
				return cachedResult;
			}


			var height = 0.0;
			var minHeight = 0.0;
			var width = 0.0;
			var minWidth = 0.0;

			var visibleChildrensCount = (double)Children.Count(c => c.IsVisible);
			var rowsCount = Math.Ceiling(visibleChildrensCount / MaxItemsPerRow);
			height = minHeight = (ItemHeight + RowSpacing) * rowsCount - RowSpacing;
			width = minWidth = widthConstraint;

			// store our result in the cache for next time
			var result = new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
			_measureCache[constraintSize] = result;
			return result;
		}

		protected override void InvalidateMeasure()
		{
			_measureCache.Clear();
			base.InvalidateMeasure();
		}

		readonly Dictionary<Size, SizeRequest> _measureCache = new Dictionary<Size, SizeRequest>();

	}
}
