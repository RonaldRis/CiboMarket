
using CiboMarket.Models;
using CiboMarket.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiboMarket.Views.TabbedMain.PerfilVistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DireccionesPage : ContentPage
	{

		public DireccionesPage ()
		{
			InitializeComponent ();
            CargarDIREC();
        }

        private async void Btn2_Clicked(object sender, EventArgs e)
        {
            
        }

        public async void CargarDIREC()
        {
            try
            {
                Rest enlaceSevidor = new Rest();
                List<direcciones> ldirec = await enlaceSevidor.GetAll<direcciones>("direcciones");
                if (ldirec.Count != 0)
                {
                    //Agregar codigo id
                    int idlogin = Convert.ToInt32(App.Current.Properties["ID"]);
                    List<direcciones> ldirecUsuario = new List<direcciones>();
                    foreach (var item in ldirec)
                    {
                        if (item.idUser == idlogin)
                        {
                            ldirecUsuario.Add(item);
                        }
                    }

                    mainstack.VerticalOptions = LayoutOptions.StartAndExpand;

                    lbl1.IsVisible = false;
                    lbl2.IsVisible = false;
                }
            }
            catch (Exception e)
            {
                Debug.Print("DIRECIONES ERROR: "+e.Message);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CargarDIREC();
        }
    }
}