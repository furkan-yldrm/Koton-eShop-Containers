using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopOnContainers.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Kayit_Tapped(object sender, EventArgs e)
        {
            Registerstack.IsVisible = true;
            Loginstack.IsVisible = false;
        }

        private void Giris_Tapped(object sender, EventArgs e)
        {
            Registerstack.IsVisible = false;
            Loginstack.IsVisible = true;
        }
    }
}