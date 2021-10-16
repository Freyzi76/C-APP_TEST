using SchoolApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolApp
{
    public partial class App : Application
    {

        public const string API_BASE_URL = "https://192.168.1.82";

        public const string Token = "null";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {

            

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
