

namespace CiboMarket.Views.TabbedMain
{
    using Android.Widget;
    using CiboMarket.Models;
    using CiboMarket.Services;
    using CiboMarket.ViewModels;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {

        OpcionesViewModel viewModel;
        public usuario userlogged { get; set; }


        public Page3()
        {
            InitializeComponent();
            viewModel = new OpcionesViewModel();
            BindingContext = viewModel;

        }

        private void getUserLogged()
        {
            Rest restx = new Rest();
            userlogged = restx.Get<usuario>("usuarios", App.Current.Properties["ID"].ToString()).Result;
            Task.Delay(1000);
            txtNombre.Text = userlogged.nombre;
            txtUsername.Text = userlogged.C_User;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Opciones;
            if (item == null)
                return;

            Toast.MakeText(Android.App.Application.Context, item.Label1, ToastLength.Short).Show();
            if (item.Label1 == "Tus direcciones")
            {
                //await Navigation.PushAsync(new DireccionesPage());

            }
            else
            {
                if (item.Label1 == "Ayuda")
                {
                    //await Navigation.PushAsync(new AyudaPage());

                }
                else
                    if (item.Label1 == "Preferencias")
                {
                    //await Navigation.PushAsync(new PreferenciasPage());

                }
                else
                    if (item.Label1 == "Formas de Pago")
                {
                    //await Navigation.PushAsync(new FormasDePagoPage());

                }
            }

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
        public void setUser(usuario u)
        {
            userlogged = u;
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            App.Current.Properties["Remember"] = String.Empty;
            App.Current.Properties["User"] = String.Empty;
            Navigation.PopAsync();
            //Navigation.PushAsync(new LoginP());
        }

        private void CompBtn_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new CompletarPerfilPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new CompletarPerfilPage());
        }
    }
}