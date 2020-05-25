using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute("itemdetailpage", typeof(ItemDetailPage));
			Routing.RegisterRoute("newitempage", typeof(NewItemPage));
		}
	}
}
