using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiboMarket.Views.TabbedMain.PerfilVistas
{

    public class Opciones2 //Model
    {

        public string Label1 { get; set; }
        public string Label2 { get; set; }


    }


    class PreferenciasViewModel
    {
        public ObservableCollection<Opciones2> All { get; set; }

        public PreferenciasViewModel()
        {
            All = new ObservableCollection<Opciones2>
            {

                new Opciones2
                {
                    Label1="Editar mi numero de telefono",
                    Label2="Opcional"
                },
                new Opciones2
                {
                    Label1="Cambiar contraseña",
                    Label2="Opcion de seguridad"
                }
            };


        }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreferenciasPage : ContentPage
	{
        PreferenciasViewModel viewModel;
		public PreferenciasPage ()
		{
			InitializeComponent ();
            viewModel = new PreferenciasViewModel();
            this.BindingContext = viewModel;
        }
	}
}