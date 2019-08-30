
namespace CiboMarket.ViewModels
{
    using Cibo.Models;
    using CiboMarket.Models;
    using CiboMarket.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class DetallePedidoViewModel : BaseViewModel
    {
        public ObservableCollection<PlatilloCompra> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public LocalSQLITE DBlocal { get; set; }
        public pedidos pedidoSelected { get; set; }
        public String TiempoEspera { get; set; }
        public float CostoTotal { get; set; }
        public int idUser = Convert.ToInt32(App.Current.Properties["ID"].ToString());




        public DetallePedidoViewModel(pedidos p)
        {
            pedidoSelected = p;
            DataStore = new Rest();
            Items = new ObservableCollection<PlatilloCompra>();
            DBlocal = new LocalSQLITE();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try // RECUPERO LOCALMENTE SQLite -> hago el Observable collection
            {
                Items.Clear();

                LocalSQLITE DB = new LocalSQLITE();

                //var PlatillosPedidosAPI = await DataStore.GetAll<platillosPedidos>("platillosPedidos");
                //var ItemsFromAPI = await DataStore.GetAll<platillos>("platillos");
                ////Dictionary de platillospedidos
                ///
                List<platillosPedidos> PlatillosPedidosAPI = await DB.conexion.QueryAsync<platillosPedidos>("SELECT * FROM  platillosPedidos");
                List<platillos> ItemsFromAPI = await DB.conexion.QueryAsync<platillos>("SELECT * FROM platillos");

                Dictionary<int?, platillosPedidos> dpp = new Dictionary<int?, platillosPedidos>();

                foreach (var platiPedi in PlatillosPedidosAPI)
                {
                    if (platiPedi.idPed == pedidoSelected.idPedido)
                    {
                        try
                        {
                            dpp.Add(platiPedi.idPlat, platiPedi);
                        }
                        catch (Exception) { }
                    }
                }

                CostoTotal = 0;
                foreach (var platilloAPI in ItemsFromAPI)
                {
                    if (dpp.ContainsKey(platilloAPI.idPlatillo))
                    {
                        platillos platilloPedido = platilloAPI;
                        platilloPedido.cant = dpp[platilloAPI.idPlatillo].cant;
                        platilloPedido.subtotal = dpp[platilloAPI.idPlatillo].subtotal;
                        Items.Add(new PlatilloCompra(platilloPedido));
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
