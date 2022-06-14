using eShopOnContainers.Core.Helpers;
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
    public partial class Deneme : ContentPage
    {
        IAuth auth;
        public Deneme()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {                    
                var user = auth.SignUpwithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
                if (user != null)
                {
                    await DisplayAlert("Basarili", "Yeni kullanıcı eklendi.", "OK");
                    var signOut = auth.SignOut();
                    if (signOut)
                    {
                        Application.Current.MainPage = new AppShell();
                    }
                }
                else
                {
                    await DisplayAlert("Hata", "Bir hata olustu.", "OK");
                }
        }
    }
}
