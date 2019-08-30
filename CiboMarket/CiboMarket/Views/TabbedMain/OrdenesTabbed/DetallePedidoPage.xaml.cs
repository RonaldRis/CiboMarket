
namespace CiboMarket.Views.TabbedMain.OrdenesTabbed
{
    using CiboMarket.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePedidoPage : ContentPage
    {
        public DetallePedidoViewModel viewmodel { get; set; }

        public DetallePedidoPage(DetallePedidoViewModel p)
        {
            InitializeComponent();
            viewmodel = p;
            BindingContext = viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.LoadItemsCommand.Execute(null);

        }
    }
}