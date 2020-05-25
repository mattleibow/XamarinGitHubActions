using MobileApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp.Views
{
	[QueryProperty(nameof(ItemId), "itemid")]
	public partial class ItemDetailPage : ContentPage
	{
		private readonly ItemDetailViewModel _viewModel;
		private string _itemId;

		public string ItemId
		{
			get => _itemId;
			set => _itemId = Uri.UnescapeDataString(value);
		}

		public ItemDetailPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new ItemDetailViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_viewModel.LoadItemCommand.Execute(ItemId);
		}
	}
}
