using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchoolApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyUser : ContentView
    {
        private string User;

        public ModifyUser(string user)
        {
            InitializeComponent();

            User = user;

            test.Text = User;
        }





    }
}