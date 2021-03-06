using eShopOnContainers.Core.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels
{
    public class GirisViewModel : INotifyPropertyChanged
    { public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        
        public GirisViewModel()
        {
            LoginCommand = new Command(Login, LoginCanExecute);
            RegisterCommand = new Command(Register, RegisterCanExecute);
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertChanged("Name");
                OnPropertChanged("CanRegister");
            }
        }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertChanged("Email");
                OnPropertChanged("CanLogin");
                OnPropertChanged("CanRegister");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertChanged("Password");
                OnPropertChanged("CanLogin");
                OnPropertChanged("CanRegister");
            }
        }
        private string confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                OnPropertChanged("ConfirmPassword");
                OnPropertChanged("CanRegister");
            }
        }

        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
            }
        }

        public bool CanRegister
        {
            get
            {
                return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && !string.IsNullOrEmpty(Name);
            }
        }
       
        private bool RegisterCanExecute(object parameter)
        {
            return CanRegister;
        }

        private async void Register(object parameter)
        {
            if (confirmPassword != password)
            {
                await App.Current.MainPage.DisplayAlert("Error", "ŞİFRE YANLIŞ!!", "Tamam");
            }
            else
            {
                bool result = await Auth.RegisterUser(Name, Email, Password);
                if (result)
                  await  App.Current.MainPage.Navigation.PopAsync();
            }

        }

        private async void Login(object parameter)
        {
            bool result = await Auth.AuthenticateUser(Email, Password);
            if (result)
              await  App.Current.MainPage.Navigation.PopAsync();
        }

        private bool LoginCanExecute(object parameter)
        {
            return CanLogin;
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
