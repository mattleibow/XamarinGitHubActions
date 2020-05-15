using MobileApp.Infrastructure;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public Command OpenWebCommand { get; }

		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() => Browser.OpenAsync("https://xamarin.com"));
		}
	}
}
