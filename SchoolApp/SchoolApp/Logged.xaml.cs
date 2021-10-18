using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logged : TabbedPage
    {

        private string Token = "";

        public Logged(string token)
        {
            InitializeComponent();

            Token = token;

            GetUsers();
        }

        private void GetUsers()
        {

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            var result = client.GetStringAsync(App.API_BASE_URL + "/api/Courses/users").Result;

            test.Text = result;


        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var ResultGet = client.GetStringAsync(App.API_BASE_URL + "/api/Courses/execute").Result;

            ButtonToken.Text = ResultGet;

        }
    }
}