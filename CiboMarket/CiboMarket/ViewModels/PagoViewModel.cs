

namespace CiboMarket.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class TargetPago //Model
    {
        public string Img { get; set; }
        public string NombreTarjeta { get; set; }
    }



    class PagoViewModel : BaseViewModel
    {
        public ObservableCollection<TargetPago> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PagoViewModel()
        {
            Items = new ObservableCollection<TargetPago>();
            List<TargetPago> LOp = new List<TargetPago>
            {


                new TargetPago
                {
                    Img="Visa.png",
                    NombreTarjeta="Visa"
                },

                new TargetPago
                {
                    Img="Paypal.png",
                    NombreTarjeta="Paypal"
                },
                new TargetPago
                {
                    Img="AmericanExpress.png",
                    NombreTarjeta="American Express"
                },
                new TargetPago
                {
                    Img="MasterCard.png",
                    NombreTarjeta="Master Card"
                },
            };
            foreach (var item in LOp)
            {
                Items.Add(item);
            }

        }
    }
}
