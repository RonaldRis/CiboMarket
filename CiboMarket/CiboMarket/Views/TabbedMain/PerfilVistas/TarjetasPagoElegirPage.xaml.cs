

namespace CiboMarket.Views.TabbedMain.PerfilVistas
{
    using Android.Widget;
    using Cibo.Models;
    using CiboMarket.Models;
    using CiboMarket.Services;
    using CiboMarket.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TarjetasPagoElegirPage : ContentPage
	{
        PagoViewModel viewModel { get; set; }
        pedidos pedidoActual;

        public TarjetasPagoElegirPage (pedidos p)
		{
			InitializeComponent ();
            pedidoActual = p;
            viewModel = new PagoViewModel();
            this.BindingContext = viewModel;
        }


        private async void MetodoSelected(TargetPago item)
        {

            Toast.MakeText(Android.App.Application.Context, item.NombreTarjeta, ToastLength.Short).Show();
            pedidoActual.metodoPago = item.NombreTarjeta;



            LocalSQLITE DB = new LocalSQLITE();
            Rest restx = new Rest();

            pedidoActual = await restx.Post<pedidos>("pedidos", pedidoActual);


            //List<pedidos> pedidosAPI =  restx.GetAll<pedidos>("pedidos").Result;
            //Toast.MakeText(Android.App.Application.Context, "Haciendo pedido", ToastLength.Long).Show();
            //await Task.Delay(3000);
            //List<pedidos> pedidosUser = new List<pedidos>();
            //foreach (pedidos pedi in pedidosAPI)
            //{
            //    if (pedi.idUser == pedidoActual.idUser)
            //    {
            //        pedidosUser.Add(pedi);
            //    }
            //}

            //pedidoActual = pedidosUser[pedidosUser.Count - 1];
            List<pedidos> pedidosall = DB.conexion.QueryAsync<pedidos>("Select * FROM [pedidos] ").Result;
            if (pedidosall.Count==0)
            {
                pedidoActual.idPedido =  1;
            }
            else
            {
                pedidoActual.idPedido = pedidosall.Count + 1;
            }
            var ignorarrr = await DB.conexion.InsertAsync(pedidoActual);

            Toast.MakeText(Android.App.Application.Context, "Pedido siendo tramitado", ToastLength.Long).Show();
            

            //Obtener el pedido actual
            


            List<platillos> lDBlocaPlat = DB.conexion.QueryAsync<platillos>("Select * FROM [platillos] " +
                    "WHERE cant>0 ORDER BY idRes ASC").Result;

            List<platillosPedidos> lPlatiPedidos = new List<platillosPedidos>();
            foreach (var itemDB in lDBlocaPlat)
            {
                try
                {
                    List<platillosPedidos> platillosCant = DB.conexion.QueryAsync<platillosPedidos>("Select * FROM [platillosPedidos] ").Result;
                    platillosPedidos newPlatiPedido = new platillosPedidos();

                    if (platillosCant.Count==0)
                    {
                        newPlatiPedido.idPlatPed = 1;
                    }
                    else
                    {
                        newPlatiPedido.idPlatPed = platillosCant.Count + 1;
                    }
                    newPlatiPedido.cant = itemDB.cant;
                    newPlatiPedido.subtotal = itemDB.subtotal;
                    newPlatiPedido.idPlat = itemDB.idPlatillo;
                    newPlatiPedido.idPed = pedidoActual.idPedido;

                    newPlatiPedido = await restx.Post<platillosPedidos>("platillosPedidos", newPlatiPedido);
                    try
                    {
                        var estoppaquenoexplote = await DB.conexion.InsertAsync(newPlatiPedido);
                    }
                    catch (Exception X)
                    {
                        Debug.Print(X.Message);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print("ERROR PlatillosPedidosPage:  " + ex.Message);
                }
            }

            //Ahora debo resetear todas las cantidades

            var ignorar = await DB.conexion.QueryAsync<platillos>("UPDATE [platillos] SET cant=0, subtotal=0");

            Toast.MakeText(Android.App.Application.Context, "Pedido siendo tramitado", ToastLength.Long).Show();
            try
            {
                await Navigation.PopModalAsync();
            }
            catch (Exception) { }

            try
            {
                await Navigation.PopModalAsync();
            }
            catch (Exception) { }
            try
            {
                await Navigation.PopModalAsync();
            }
            catch (Exception) { }
            try
            {
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception) { }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as TargetPago;
            if (item == null)
                return;
            MetodoSelected(item);
        }
    }
}