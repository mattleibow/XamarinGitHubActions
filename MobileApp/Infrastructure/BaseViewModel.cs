using MobileApp.Models;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MobileApp.Infrastructure
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private bool isBusy = false;
		private string title = string.Empty;

		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
