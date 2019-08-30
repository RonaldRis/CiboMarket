using System;
using System.Collections.Generic;
using System.Text;

namespace CiboMarket.ViewModels
{
    using CiboMarket.Models;
    using CiboMarket.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class Opciones //Model
    {

        public string Img { get; set; }
        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Img2 { get; set; }


    }



    class OpcionesViewModel : BaseViewModel
    {
    //La clase OPCIONES está en este archivo, datos estaticos
    public static IEnumerable<Opciones> All { get; set; }  

        static OpcionesViewModel()
        {
            List<Opciones> LOp = new List<Opciones>
            {

                new Opciones
                {
                    Img="ubication.png",
                    Label1="Tus direcciones",
                    Label2="Ver",
                    Img2="next.png"
                },
                new Opciones
                {
                    Img="pago.png",
                    Label1="Formas de Pago",
                    Label2="Ver",
                    Img2="next.png"
                },
                new Opciones
                {
                    Img="configuracion.png",
                    Label1="Preferencias",
                    Label2="",
                    Img2="next.png"
                },
                new Opciones
                {
                    Img="help.png",
                    Label1="Ayuda",
                    Label2="",
                    Img2="next.png"
                }
            };

            All = LOp;
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                foreach (var item in All)
                {
                    Items.Add(item);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }





        public ObservableCollection<Opciones> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public OpcionesViewModel()
        {
            DataStore = new Rest();
            Items = new ObservableCollection<Opciones>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

    }
}
