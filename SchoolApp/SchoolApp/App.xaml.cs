using SchoolApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolApp
{
    public partial class App : Application
    {

        public const string API_BASE_URL = "https://192.168.1.82";


        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
