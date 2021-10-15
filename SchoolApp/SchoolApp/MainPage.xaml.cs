using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchoolApp
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();



            LoginBtn.Clicked += Login;

        }


        private async void Login(object sender, EventArgs e)
        {

            var Client = new RestClient("https://www.youtube.com");

            //var UrlRequest = "​/api/User/login/" + Username.Text​ + "/" + Password.Text;

            var UrlRequest = "/s/desktop/ec88e548/cssbin/www-main-desktop-watch-page-skeleton.css";

            var request = new RestRequest(UrlRequest, DataFormat.Json);

            var response = await Client.ExecuteAsync(request);


            
            Result.Text = "result  " + response.Content; 

        }


    }

}
