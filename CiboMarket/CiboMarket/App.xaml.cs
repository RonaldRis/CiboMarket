using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CiboMarket
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Solo para que no de error agrego las otras lineas, es prueba
            Application.Current.Properties["ID"] = 2;
            Application.Current.Properties["REMEMBER"] = "YES";
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
