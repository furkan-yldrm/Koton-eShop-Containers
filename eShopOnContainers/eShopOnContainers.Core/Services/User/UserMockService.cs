using eShopOnContainers.Core.Models.User;
using System;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.User
{
    public class UserMockService : IUserService
    {
        private UserInfo MockUserInfo = new UserInfo
        {
            UserId = Guid.NewGuid().ToString(),
            Name = "Jhon",
            LastName = "Doe",
            PreferredUsername = "Jdoe",
            Email = "jdoe@eshop.com",
            EmailVerified = true,
            PhoneNumber = "202-555-0165",
            PhoneNumberVerified = true,
            Address = "Seattle, WA",
            Street = "120 E 87th Street",
            ZipCode = "98101",
            Country = "United States",
            State = "Seattle",
            CardNumber = "378282246310005",
            CardHolder = "American Express",
            CardSecurityNumber = "1234"
        };

        public async Task<UserInfo> GetUserInfoAsync(string authToken)
        {
            await Task.Delay(10);
            return MockUserInfo;
        }
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10.0);
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            return Task.Delay(1000).ContinueWith((task) => true);
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}