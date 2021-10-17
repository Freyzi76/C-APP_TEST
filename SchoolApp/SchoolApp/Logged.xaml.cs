using System;
using System.Collections.Generic;
using System.Linq;
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

            ResultToken.Text = Token;
        }





    }
}