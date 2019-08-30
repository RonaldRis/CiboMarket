

namespace CiboMarket.Views.TabbedMain.PerfilVistas
{
    using CiboMarket.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tarjetasdepago : ContentPage
	{
        PagoViewModel viewModel;

		public Tarjetasdepago ()
		{
			InitializeComponent ();
            viewModel = new PagoViewModel();
            this.BindingContext = viewModel;
		}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}