using Moflix.Core.Application.DTOs.Account;

namespace Moflix.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

        Task<string> ConfirmAccountAsync(string userId, string token);

        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);

        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);

        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);

        Task SignOutAsync();
    }
}