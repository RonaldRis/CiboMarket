

namespace CiboMarket.Views
{
    using CiboMarket.Models;
    using CiboMarket.Services;
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginP : ContentPage
    {
        Dictionary<string, usuario> dU = new Dictionary<string, usuario>();
        List<usuario> lU = new List<usuario>();
        public LoginP()
        {
            InitializeComponent();
        }


        public async void cargarDatos() //Aqui lee, verifica y luego inicia sesion si corresponde
        {
            dU = new Dictionary<string, usuario>();
            try
            {

                Rest r = new Rest();
                lU = await r.GetAll<usuario>("usuarios");
                await Task.Delay(3000);
                if (lU == default(List<usuario>))
                {
                    await DisplayAlert("Error", "Verifique la calidad de su conexión a internet", "aceptar");
                }
                else
                {
                    foreach (var item in lU)
                    {
                        try
                        {
                            dU.Add(item.C_User, item);
                        }
                        catch (Exception ex)//En caso que existan dos username iguales o un dato corrupto
                        {
                            Debug.Print("Cargando usuarios " + ex.Message);
                        }
                    }
                    if (dU.ContainsKey(txtUser.Text) && dU[txtUser.Text].pass == txtPass.Text)
                    {
                        if (remember.IsToggled)
                        {
                            Application.Current.Properties["ID"] = dU[txtUser.Text].idUser;
                            Application.Current.Properties["REMEMBER"] = "YES";
                        }
                        else
                        {
                            Application.Current.Properties["ID"] = dU[txtUser.Text].idUser;
                            Application.Current.Properties["REMEMBER"] = "NO";
                        }
                        await Application.Current.SavePropertiesAsync();
                        await Navigation.PopAsync();
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Error, el usuario o contraseña son incorrectos", "Aceptar");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Print("Cargar datos erros login: " + ex.Message);
            }
        }
        public async void Alerta()
        {
            await DisplayAlert("Error", "Verifique la calidad de su conexión a internet", "Aceptar");
        }


        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new Register());
        }



        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            AI.IsRunning = true;

            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("Error", "Error, ninguno de los campos puede quedar vacio", "Aceptar");
            }
            else
            {
                try
                {
                    cargarDatos(); //Aqui lee, verifica y luego inicia sesion si corresponde

                }
                catch (Exception)
                {

                }
            }

            AI.IsRunning = false;
        }


    }
}