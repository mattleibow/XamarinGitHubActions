using MobileApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class NewItemPage : ContentPage
	{
		private readonly NewItemViewModel _viewModel;

		public NewItemPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new NewItemViewModel();
		}

		private async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", _viewModel.Item);
			await Shell.Current.Navigation.PopModalAsync();
		}

		private async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.Navigation.PopModalAsync();
		}
	}
}
