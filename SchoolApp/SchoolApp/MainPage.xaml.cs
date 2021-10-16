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


        public MainPage()
        {
            InitializeComponent();



            LoginBtn.Clicked += Login;

        }


        private async void Login(object sender, EventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            var result = await client.GetStringAsync(App.API_BASE_URL + "/api/User/login/" + Username.Text + "/" + Password.Text);

            TokenTakeCare.Set(result);

            Result.Text = "result  " + result;

        }


    }

}
