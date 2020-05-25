using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MobileApp.Services;
using Xamarin.Forms;

namespace MobileApp
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
			AppCenter.Start(
				"android=a793219c-529a-4f70-86cb-30e9f981bbac;" +
				 "ios=a73ac036-537f-4fb4-89e1-8707cc4c981f",
				 typeof(Analytics), typeof(Crashes));
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
