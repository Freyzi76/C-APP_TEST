using RestSharp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolApp
{
    public partial class App : Application
    {

        private const string API_BASE_URL = "http://127.0.0.1:80/";

        public static RestClient Client;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

            Client = new RestClient(API_BASE_URL);

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
