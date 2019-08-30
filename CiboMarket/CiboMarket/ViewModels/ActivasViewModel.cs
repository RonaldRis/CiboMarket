
namespace CiboMarket.ViewModels
{
    using Android.Widget;
    using Cibo.Models;
    using CiboMarket.Models;
    using CiboMarket.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class ActivasViewModel : BaseViewModel
    {
        public ObservableCollection<pedidos> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public LocalSQLITE DBlocal { get; set; }
        public int idUser = Convert.ToInt32(App.Current.Properties["ID"].ToString());




        public ActivasViewModel()
        {
            DataStore = new Rest();
            Items = new ObservableCollection<pedidos>();
            DBlocal = new LocalSQLITE();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        public async Task ExecuteLoadItemsCommand()  //Actualiza el listview
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                //var ItemsFromAPI = await DataStore.GetAll<pedidos>("pedidos");
                LocalSQLITE DB = new LocalSQLITE();
                var ItemsFromAPI = await DB.conexion.QueryAsync<pedidos>("SELECT * FROM pedidos");


                if (ItemsFromAPI.Count == 0)
                {
                    Toast.MakeText(Android.App.Application.Context, "No hay ordenes activas", ToastLength.Short).Show();
                }
                else
                {

                    foreach (var itemAPI in ItemsFromAPI)
                    {
                        if (itemAPI.idUser == idUser && itemAPI.estado != "Completado")
                        {
                            Items.Add(itemAPI);
                        }
                    }

                }


                IsBusy = false;
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
