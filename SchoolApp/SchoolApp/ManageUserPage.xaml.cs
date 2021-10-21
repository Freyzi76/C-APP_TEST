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
    public partial class ManageUserPage : ContentPage
    {

        private UserModel USER;

        private string TOKEN;

        private bool ISNEWUSER;

        public ManageUserPage(UserModel user, string Token, bool IsNewUser)
        {
            InitializeComponent();

            USER = user;

            TOKEN = Token;

            ISNEWUSER = IsNewUser;


            if (ISNEWUSER)
            {
                TitleLabel.Text = "Ajouter l'utilisateur";

                UserName.Placeholder = USER.Name;

                UserFirstName.Placeholder = USER.Firstname;

                UserEmail.Placeholder = USER.Email;

                ResetPassword.IsEnabled = false;
                ResetPassword.IsToggled = true;

                BtnConfirm.Text = "Ajouter";


            }
            else 
            {


                UserName.Text = USER.Name;

                UserFirstName.Text = USER.Firstname;

                UserEmail.Text = USER.Email;

                BtnConfirm.Text = "Modifier";

            }

        }

        private void ExecuteManageUser(object sender, EventArgs e)
        {

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);


            if (ISNEWUSER)
            {

                if (UserName.Text != USER.Name && UserFirstName.Text != USER.Firstname && UserEmail.Text != USER.Email)
                {



                    var ResultAddUser = client.GetStringAsync(App.API_BASE_URL + "/api/User/ExecuteManageUser/" + USER.Email + "/" + UserName.Text + "/" + UserFirstName.Text + "/" + UserEmail.Text + "/" + ResetPassword.IsToggled + "/" + ISNEWUSER).Result;

                    ResultLabel.Text = ResultAddUser;

                    Navigation.RemovePage(this);

                }

            }
            else
            {

                string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/ExecuteManageUser/" + USER.Email + "/" + UserName.Text + "/" + UserFirstName.Text + "/" + UserEmail.Text + "/" + ResetPassword.IsToggled + "/" + ISNEWUSER).Result;

                ResultLabel.Text = result;

                Navigation.RemovePage(this);

            }




        }




    }
}