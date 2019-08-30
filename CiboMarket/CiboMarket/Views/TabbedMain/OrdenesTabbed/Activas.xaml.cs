
namespace CiboMarket.Views.TabbedMain.OrdenesTabbed
{
    using CiboMarket.Models;
    using CiboMarket.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Activas : ContentPage
    {
        public ViewModels.ActivasViewModel viewmodel { set; get; }

        public Activas()
        {
            InitializeComponent();
            viewmodel = new ActivasViewModel();
            BindingContext = viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.LoadItemsCommand.Execute(null);

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as pedidos;
            if (item == null)
                return;
            await Navigation.PushAsync(new DetallePedidoPage(new DetallePedidoViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
    
}