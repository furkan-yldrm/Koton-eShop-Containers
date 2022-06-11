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
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }
        private async void Button_Kayit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void Button_Giris(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}