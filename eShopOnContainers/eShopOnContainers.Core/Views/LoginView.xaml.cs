using eShopOnContainers.Core.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using eShopOnContainers.Core;
using eShopOnContainers.Core.Helpers;

namespace eShopOnContainers.Core.Views
{
    public partial class LoginView : ContentPage
    {
        private bool _animate;
        IAuth auth;
        public LoginView()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
             /*   string token = await auth.LoginwithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
                if (token != string.Empty)
                {
                    await DisplayAlert("Uid", token, "OK");
                    Application.Current.MainPage = new HomePage();
                }
                else
                {
                    await DisplayAlert("Giriş başarısız", "Email veya sifre yanlis", "OK");
                }*/
        }

        protected override async void OnAppearing()
        {
            var content = this.Content;
            this.Content = null;
            this.Content = content;

			var vm = BindingContext as LoginViewModel;
            if (vm != null)
            {
                vm.InvalidateMock();

				if (!vm.IsMock)
				{
					_animate = true;
					await AnimateIn();
				}
            }
        }

        protected override void OnDisappearing()
        {
            _animate = false;
        }

        public async Task AnimateIn()
        {
			if (Device.RuntimePlatform == Device.UWP)
            {
                return;
            }

            await AnimateItem(Banner, 10500);
        }

        private async Task AnimateItem(View uiElement, uint duration)
        {
            try
            {
                while (_animate)
                {
					await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);
					await Task.WhenAll(
						uiElement.FadeTo(1, duration, Easing.SinInOut),
						uiElement.LayoutTo(new Rectangle(new Point(0, 0), new Size(uiElement.Width, uiElement.Height))),
						uiElement.FadeTo(.9, duration, Easing.SinInOut),
						uiElement.ScaleTo(1.15, duration, Easing.SinInOut)
					);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Deneme());
        }
    }
}