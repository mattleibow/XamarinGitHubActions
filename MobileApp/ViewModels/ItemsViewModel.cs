using MobileApp.Infrastructure;
using MobileApp.Models;
using MobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableCollection<Item>();

			LoadItemsCommand = new Command(async () => await OnLodItemsAsync());

			MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
			{
				Items.Add(item);
				await DataStore.AddItemAsync(item);
			});
		}

		public ObservableCollection<Item> Items { get; set; }

		public Command LoadItemsCommand { get; set; }

		private async Task OnLodItemsAsync()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items)
				{
					Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
