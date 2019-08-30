using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CiboMarket.Droid
{
    using System;

    using Android.App;
    using Android.Content.PM;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    [Activity(Label = "CiboMarket", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();



            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            if (false)
            {
                base.OnBackPressed();
            }
            Toast.MakeText(Android.App.Application.Context, "No se puede regresar", ToastLength.Short).Show();
        }
    }
   
}