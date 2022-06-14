using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopOnContainers.Core.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using eShopOnContainers.Droid;
[assembly: Dependency(typeof(AuthDroid))]
namespace eShopOnContainers.Droid
{
    public class AuthDroid : IAuth
    {

            public bool IsSignIn()
            {
                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                return user != null;
            }

        public async Task<string> LoginwithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = user.User.Uid;
                return token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {

                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<string> SignUpwithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var token = user.User.Uid;
                return token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {

                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }        
        }
    }
}