using Android.Widget;
using CiboMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Cibo.Models
{
    public class PlatilloCompra : platillos, INotifyPropertyChanged
    {
        

        public Command AumentarCant { get; set; }
        public Command DisminuirCant { get; set; }

        public PlatilloCompra(platillos plati)
        {
            subtotal = plati.subtotal;
            cant = plati.cant;
            categoria = plati.categoria;
            imgPath = plati.imgPath;
            price = plati.price;
            descp = plati.descp;
            nombre = plati.nombre;
            idRes = plati.idRes;
            idPlatillo = plati.idPlatillo;

            AumentarCant = new Command(AumentarCantidad);
            DisminuirCant = new Command(DisminuirCantidad);
        }


        private void AumentarCantidad()
        {
            cant++;
            subtotal = cant * price;


            LocalSQLITE BaseDatos = new LocalSQLITE();
            platillos plati = new platillos();

            plati.subtotal = subtotal;
            plati.cant = cant;
            plati.categoria = categoria;
            plati.imgPath = imgPath;
            plati.price = price;
            plati.descp = descp;
            plati.nombre = nombre;
            plati.idRes = idRes;
            plati.idPlatillo = idPlatillo;


            if (BaseDatos.conexion.UpdateAsync(plati).Result == 1)
            {
                Debug.Print(this.nombre + " cant " + this.cant);
                Toast.MakeText(Android.App.Application.Context, plati.nombre + " agregada",ToastLength.Short).Show();
            }
            else
            {
                Debug.Print(this.nombre + " cant Not modified");
            }
        }


        private void DisminuirCantidad()
        {
            if (cant > 0)
            {
                cant--;
                subtotal = cant * price;

                platillos plati = new platillos();

                plati.subtotal = subtotal;
                plati.cant = cant;
                plati.categoria = categoria;
                plati.imgPath = imgPath;
                plati.price = price;
                plati.descp = descp;
                plati.nombre = nombre;
                plati.idRes = idRes;
                plati.idPlatillo = idPlatillo;

                LocalSQLITE BaseDatos = new LocalSQLITE();

                if (BaseDatos.conexion.UpdateAsync(plati).Result == 1)
                {
                    Debug.Print(this.nombre + " cant " + this.cant);
                    Toast.MakeText(Android.App.Application.Context, plati.nombre + " quitada",ToastLength.Short).Show();
                }
                else
                {
                    Debug.Print(this.nombre + " cant Not modified");
                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "Prueba agregar en vez de quitar ;)", ToastLength.Long).Show();
            }
        }



        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion




    }
}
