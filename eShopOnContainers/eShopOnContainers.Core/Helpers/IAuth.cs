using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Helpers
{
    public interface IAuth
    {
        Task<string> SignUpwithEmailAndPassword(string email, string password);

        bool SignOut();
        bool IsSignIn();
    }
}