using eShopOnContainers.Core.Services.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.ViewModels.Helpers
{
    public interface Iauth
    {
        Task<bool> RegisterUser(string name, string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }
    public class Auth
    {

        private static Iauth auth = DependencyService.Get<Iauth>();

        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
                return await auth.RegisterUser(name, email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }

        }

        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                return await auth.AuthenticateUser(email, password);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", ex.Message, "OK");
                return false;
            }
        }

        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }
        public static string GetCurrentUserUd()
        {
            return auth.GetCurrentUserId();
        }
    }
}