using eShopOnContainers.Core.Models.User;
using System.Threading.Tasks;

namespace eShopOnContainers.Core.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);

        Task<bool> LoginAsync(string username, string password);
        Task<double> GetCurrentPayRateAsync();
        Task<bool> SendOtpCodeAsync(string phoneNumber);
        Task<bool> VerifyOtpCodeAsync(string code);

        Task<AuthenticatedUser> GetUserAsync();
    }
}
