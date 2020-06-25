using System;
using Xamarin.Forms;

namespace FormStandard
{
    public class StandardListView : ListView
	{
		public StandardListView()
		{
			BackgroundColor = Color.Transparent;
			this.ItemTapped += Handle_ItemTapped;
			this.ItemAppearing += Handle_ItemAppearing;
			this.ItemDisappearing += Handle_ItemDisappearing;
			this.ItemSelected += Handle_ItemSelected;
			this.Refreshing += Handle_Refreshing;
		}

		public static readonly BindableProperty ItemTappedCommandProperty =
			BindableProperty.Create(nameof(ItemTappedCommandProperty), typeof(Command), typeof(StandardListView), new Command(() => { }), BindingMode.Default);
		public Command ItemTappedCommand
		{
			get { return (Command)GetValue(ItemTappedCommandProperty); }
			set { SetValue(ItemTappedCommandProperty, value); }
		}

		void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (ItemTappedCommand.CanExecute(e))
			{
				ItemTappedCommand.Execute(e);
			}
		}

		public static readonly BindableProperty ItemAppearingCommandProperty =
			BindableProperty.Create(nameof(ItemAppearingCommandProperty), typeof(Command), typeof(StandardListView), new Command(() => { }), BindingMode.Default);
		public Command ItemAppearingCommand
		{
			get { return (Command)GetValue(ItemAppearingCommandProperty); }
			set { SetValue(ItemAppearingCommandProperty, value); }
		}

		void Handle_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			if (ItemAppearingCommand.CanExecute(e))
			{
				ItemAppearingCommand.Execute(e);
			}
		}

		public static readonly BindableProperty ItemDisappearingCommandProperty =
			BindableProperty.Create(nameof(ItemDisappearingCommandProperty), typeof(Command), typeof(StandardListView), new Command(() => { }), BindingMode.Default);
		public Command ItemDisappearingCommand
		{
			get { return (Command)GetValue(ItemDisappearingCommandProperty); }
			set { SetValue(ItemDisappearingCommandProperty, value); }
		}

		void Handle_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
		{
			if (ItemDisappearingCommand.CanExecute(e))
			{
				ItemDisappearingCommand.Execute(e);
			}
		}

		public static readonly BindableProperty ItemSelectedCommandProperty =
			BindableProperty.Create(nameof(ItemSelectedCommandProperty), typeof(Command), typeof(StandardListView), new Command(() => { }), BindingMode.Default);
		public Command ItemSelectedCommand
		{
			get { return (Command)GetValue(ItemSelectedCommandProperty); }
			set { SetValue(ItemSelectedCommandProperty, value); }
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (ItemSelectedCommand.CanExecute(e))
			{
				ItemSelectedCommand.Execute(e);
			}
		}

		public static readonly BindableProperty RefreshingCommandProperty =
			BindableProperty.Create(nameof(RefreshingCommandProperty), typeof(Command), typeof(StandardListView), new Command(() => { }), BindingMode.Default);
		public Command RefreshingCommand
		{
			get { return (Command)GetValue(RefreshingCommandProperty); }
			set { SetValue(RefreshingCommandProperty, value); }
		}

		void Handle_Refreshing(object sender, EventArgs e)
		{
			if (RefreshingCommand.CanExecute(e))
			{
				RefreshingCommand.Execute(e);
			}
		}
	}
}

