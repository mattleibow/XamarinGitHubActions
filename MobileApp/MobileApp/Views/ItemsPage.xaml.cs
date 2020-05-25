using MobileApp.Models;
using MobileApp.ViewModels;
using System;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class ItemsPage : ContentPage
	{
		private readonly ItemsViewModel _viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new ItemsViewModel();
		}

		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Shell.Current.GoToAsync($"/itemdetailpage?itemid={item.Id.ToString()}");

			// Manually deselect item.
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync($"/newitempage");
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel.Items.Count == 0)
				_viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
