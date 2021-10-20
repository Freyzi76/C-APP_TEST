using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchoolApp
{
    public partial class MainPage : ContentPage
    {
        public string result = "";

        public MainPage()
        {
            InitializeComponent();


        }


        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            result = await client.GetStringAsync(App.API_BASE_URL + "/api/User/login/" + Username.Text.Trim() + "/" + Password.Text.Trim());

            Result.Text = result;

            if(result != null)
            {
                IsLog();
            }
            else
            {
                Result.Text = "no result";
            }



        }



        private void IsLog()
        {

            Application.Current.MainPage = new NavigationPage(new Logged(result));

            Navigation.RemovePage(this);

        }





    }

}
