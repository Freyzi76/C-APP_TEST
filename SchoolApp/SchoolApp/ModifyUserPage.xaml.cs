using Newtonsoft.Json;
using SchoolAPI.Models;
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
    public partial class ModifyUserPage : ContentPage
    {

        private UserModel USER;

        private string TOKEN;

        public ModifyUserPage(UserModel user, string Token)
        {
            InitializeComponent();

            USER = user;

            TOKEN = Token;

            UserName.Text = USER.Name;

            UserFirstName.Text = USER.Firstname;

            UserEmail.Text = USER.Email;


            
        }

        private void ExecuteModifyUser(object sender, EventArgs e)
        {

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);

            string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/ExecuteModifyUser/" + USER.Email + "/" + UserName.Text + "/" + UserFirstName.Text + "/" + UserEmail.Text + "/" + ResetPassword.IsToggled).Result;

            ResultLabel.Text = result;

        }




    }
}