using eShopOnContainers.Core.Helpers;
using eShopOnContainers.Core.Models.User;
using eShopOnContainers.Core.Services.RequestProvider;
using System;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<double> GetCurrentPayRateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfo> GetUserInfoAsync(string authToken)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.UserInfoEndpoint);

            var userInfo = await _requestProvider.GetAsync<UserInfo>(uri, authToken);
            return userInfo;
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
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