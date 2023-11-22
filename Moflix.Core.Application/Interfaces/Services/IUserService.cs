using Moflix.Core.Application.DTOs.Account;
using Moflix.Core.Application.ViewModels.Users;

namespace Moflix.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);

        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);

        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);

        Task<RegisterResponse> RegisterAsync(SaveUsersViewModel vm, string origin);

        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);

        Task SignOutAsync();
    }
}