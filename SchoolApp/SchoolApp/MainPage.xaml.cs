using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            var client = new HttpClient();

            var result = await client.GetAsync("http://172.16.8.140/api/Courses/users");

            Result.Text = "result  " + result; 

        }


    }

}
