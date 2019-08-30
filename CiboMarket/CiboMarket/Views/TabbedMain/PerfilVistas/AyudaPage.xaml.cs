
namespace CiboMarket.Views.TabbedMain.PerfilVistas
{
    using System.Collections.ObjectModel;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public class Opciones3 //Model
    {
        public string Label1 { get; set; }
    }


    class AyudaViewModel
    {
        public ObservableCollection<Opciones3> All { get; set; }

        public AyudaViewModel()
        {
            All = new ObservableCollection<Opciones3>
            {

                new Opciones3
                {
                    Label1="¿Quieres ser parte de la familia CIBO?"
                },
                new Opciones3
                {
                    Label1="Preguntas Frecuentes"
                }
            };
        }
    }



    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AyudaPage : ContentPage
    {
        AyudaViewModel viewmodel;
        public AyudaPage()
        {
            InitializeComponent();
            viewmodel = new AyudaViewModel();
            this.BindingContext = viewmodel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Opciones3 seleccionado = args.SelectedItem as Opciones3;
            if (seleccionado.Label1== "Preguntas Frecuentes")
            {
                //await Navigation.PushAsync(new PreguntasFrecuentes());
            }
            else if (seleccionado.Label1== "Contactenos, Envie sus recomendaciones")
            {
                //await Navigation.PushAsync(new PreguntasFrecuentes());

            }


        }
    }





}