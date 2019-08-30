using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiboMarket.Views.TabbedMain.PerfilVistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormasDePagoPage : ContentPage
	{


		public FormasDePagoPage ()
		{
			InitializeComponent ();
		}

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tarjetasdepago());
        }
    }
}