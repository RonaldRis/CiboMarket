
namespace CiboMarket.Views.TabbedMain.OrdenesTabbed
{
    using CiboMarket.Models;
    using CiboMarket.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historial : ContentPage
    {
        public HistorialViewModel viewmodel { set; get; }

        public Historial()
        {
            InitializeComponent();
            startthis();
        }
        private async void startthis()
        {
            viewmodel = new HistorialViewModel();
            BindingContext = viewmodel;
        }


        private async void ItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as pedidos;
            if (item == null)
                return;
            await Navigation.PushAsync(new DetallePedidoPage(new DetallePedidoViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.LoadItemsCommand.Execute(null);

        }
    }
}