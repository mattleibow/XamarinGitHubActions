using MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp.Views
{
	public partial class AboutPage : ContentPage
	{
		private readonly AboutViewModel _viewModel;

		public AboutPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new AboutViewModel();
		}
	}
}
