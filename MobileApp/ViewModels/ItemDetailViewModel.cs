using MobileApp.Infrastructure;
using MobileApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		private Item item;

		public ItemDetailViewModel()
		{
			var item = new Item
			{
				Id = Guid.NewGuid().ToString(),
				Text = "Sample Item",
				Description = "This is an item description."
			};

			Item = item;

			LoadItemCommand = new Command<string>(async (itemId) => await OnLoadItemAsync(itemId));
		}

		public Item Item
		{
			get => item;
			private set
			{
				SetProperty(ref item, value);
				Title = item?.Text;
			}
		}

		public Command LoadItemCommand { get; set; }

		private async Task OnLoadItemAsync(string itemId)
		{
			IsBusy = true;
			try
			{
				Item = await DataStore.GetItemAsync(itemId);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
