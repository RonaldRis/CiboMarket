namespace CiboMarket.ViewModels
{
    using Android.Widget;
    using CiboMarket.Models;
    using CiboMarket.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class Page3ViewModel : BaseViewModel
    {

        public ObservableCollection<restaurante> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public Page3ViewModel()
        {
            DataStore = new Rest();
            Items = new ObservableCollection<restaurante>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetAll<restaurante>("restaurantes");

                if (items.Count==Items.Count)
                {
                    IsBusy = false;
                    return;
                }

                Items.Clear();
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
                if (Items.Count == 0)
                {
                    Toast.MakeText(Android.App.Application.Context, "Verifique su conexión a internet", ToastLength.Short).Show();
                }
            }
        }

    }
}
