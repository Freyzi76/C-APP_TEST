using Newtonsoft.Json;
using SchoolAPI.Models;
using SchoolApp.Pages;
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

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            string result = client.GetStringAsync(App.API_BASE_URL + "/api/Courses/users").Result;

            IEnumerable<UserModel> ResultConvert = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);


            StackLayout stackLayout;


            foreach (UserModel user in ResultConvert)
            {


                Button button = new Button { Text = "Modifier", BackgroundColor = Color.YellowGreen, Margin = new Thickness(5), TextColor = Color.White, CommandParameter = user.Email};
                
                button.Clicked += ModifyUser;

                StackResultUsers.Children.Add(stackLayout = new StackLayout
                {
                    BackgroundColor = Color.Gray,
                    Margin = new Thickness(10),
                    

                    Children =
                    {
                        new Label { Text = "Prénom : " + user.Name, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17},
                        new Label { Text = "Nom : " + user.Firstname, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17},
                        new Label { Text = "Em@il : " +user.Email, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17},
                        button
                    }
                    

                });
                
            }


        }






        private async void ModifyUser(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            string GetUserEmail = button.CommandParameter.ToString();

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/ModifyUser/" + GetUserEmail).Result;

            await Navigation.PushAsync(new View1());

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