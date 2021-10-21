using Newtonsoft.Json;
using SchoolAPI.Models;
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

        private string Token;

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

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/users").Result;

            IEnumerable<UserModel> ResultConvert = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);



            FlexLayout flexLayout;

            Frame frame;

            ImageButton ReloadBtn = new ImageButton { Source = "reload.png", WidthRequest = 45, Margin = new Thickness(5), BackgroundColor = Color.FromHex("#2196F3"), Padding = 5, CornerRadius = 10 };

            ReloadBtn.Clicked += ReloadUsers;

            ImageButton AddUserBtn = new ImageButton { Source = "addUser.png", WidthRequest = 45, Margin = new Thickness(5), BackgroundColor = Color.FromHex("#198754"), Padding = 5, CornerRadius = 10, CommandParameter = "Add" };

            AddUserBtn.Clicked += ManageUser;


            StackResultUsers.Children.Add(flexLayout = new FlexLayout
            {

                Margin = new Thickness(10),

                Children =
                        {

                            AddUserBtn,
                            ReloadBtn,

                        }


            });




            foreach (UserModel user in ResultConvert)
            {

                Label Firstname = new Label { Text = "Prénom : " + user.Name, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17, TextColor = Color.Black };

                Label Name = new Label { Text = "Nom : " + user.Firstname, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17, TextColor = Color.Black };

                Label Email = new Label { Text = "Em@il : " + user.Email, Margin = new Thickness(5), HorizontalTextAlignment = TextAlignment.Center, FontSize = 17, TextColor = Color.Black };

                

                ImageButton ModifyBtn = new ImageButton { Source = "edit.png", WidthRequest = 45, Padding = 5, CornerRadius = 10, BackgroundColor = Color.FromHex("#ffc106"), Margin = new Thickness(5), CommandParameter = user.Email };

                    ModifyBtn.Clicked += ManageUser;



                ImageButton SuppBtn = new ImageButton { Source = "delete.png", WidthRequest = 45, Padding = 5, CornerRadius = 10, BackgroundColor = Color.Red, Margin = new Thickness(5), CommandParameter = user.Email };

                    SuppBtn.Clicked += SuppUser;



                FlexLayout FlexLayout = new FlexLayout
                {
                    
                    Direction = FlexDirection.RowReverse,

                    Children =
                    {

                        SuppBtn,
                        ModifyBtn,
                      
                    }

                };

                



                StackLayout stackLayout = new StackLayout
                {

                    Children =
                    {
                        Firstname,
                        Name,
                        Email,

                        FlexLayout,
                    }

                };



                StackResultUsers.Children.Add(frame = new Frame
                {
                    BackgroundColor = Color.White,
                    Margin = new Thickness(5),
                    CornerRadius = 5,
                    BorderColor = Color.FromHex("#2196F3"),
                    

                    Content = stackLayout,

                });


            }



        }





        private void ReloadUsers(object sender, EventArgs e)
        {

            StackResultUsers.Children.Clear();

            GetUsers();

        }






        private async void ManageUser(object sender, EventArgs e)
        {

            ImageButton button = (ImageButton)sender;

            string GetCommande = button.CommandParameter.ToString();

            if(GetCommande == "Add")
            {

                UserModel test = new UserModel
                {
                    Id = 0,
                    Firstname = "Prénom",
                    Name = "Nom",
                    Email = "Email"
                };


                await Navigation.PushAsync(new ManageUserPage(test, Token, true));

            }
            else
            {

                HttpClientHandler clientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
                };

                // Pass the handler to httpclient(from you are calling api)
                HttpClient client = new HttpClient(clientHandler);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/ModifyUser/" + GetCommande).Result;

                UserModel ResultConvert = JsonConvert.DeserializeObject<UserModel>(result);

                await Navigation.PushAsync(new ManageUserPage(ResultConvert, Token, false));


            }



        }




        private void SuppUser(object sender, EventArgs e)
        {

            ImageButton button = (ImageButton)sender;

            string GetUserEmail = button.CommandParameter.ToString();

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            string result = client.GetStringAsync(App.API_BASE_URL + "/api/User/SuppUser/" + GetUserEmail).Result;

            if (result == "OK")
                GetUsers();

        }





        private void Button_Clicked(object sender, EventArgs e)
        {

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; }
            };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            string ResultGet = client.GetStringAsync(App.API_BASE_URL + "/api/Courses/execute").Result;

            ButtonToken.Text = ResultGet;

        }

        
    }
}