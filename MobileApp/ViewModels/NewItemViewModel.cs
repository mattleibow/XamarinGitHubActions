using MobileApp.Infrastructure;
using MobileApp.Models;
using System;

namespace MobileApp.ViewModels
{
	public class NewItemViewModel : BaseViewModel
	{
		private Item item;

		public NewItemViewModel()
		{
			var item = new Item
			{
				Id = Guid.NewGuid().ToString(),
				Text = "Item name",
				Description = "This is an item description."
			};

			Item = item;
		}

		public Item Item
		{
			get => item;
			set
			{
				SetProperty(ref item, value);
			}
		}
	}
}
