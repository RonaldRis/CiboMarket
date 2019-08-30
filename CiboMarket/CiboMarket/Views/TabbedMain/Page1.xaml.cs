

namespace CiboMarket.Views.TabbedMain
{
    using Android.Widget;
    using CiboMarket.Models;
    using CiboMarket.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        Page3ViewModel viewmodel;

        public Page1()
        {

            InitializeComponent();
            viewmodel = new Page3ViewModel();
            BindingContext = viewmodel;




        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as restaurante;
            if (item == null)
                return;
            Toast.MakeText(Android.App.Application.Context, item.nombre, ToastLength.Short).Show();
            //await Navigation.PushAsync(new platillosPage(new PlatillosViewModel(item)));

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