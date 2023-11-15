using Microsoft.AspNetCore.Identity;
using StudentCalendarAdmin.Models;
using StudentCalendarAdmin.ViewModels;

namespace StudentCalendarAdmin.IServices
{
    public interface IAccountService
    {
        string GetResetPassword(string currentUrl);
        Task<IdentityResult> PostResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel);
        Task<SignInResult> PostLogin(LoginViewModel loginViewModel);
        Task PostLogOffAsync();
        Task<RegisterViewModel> GetRegisterAsync(string returnUrl);
        Task<bool> PostRegisterAsync(RegisterViewModel registerViewModel);
        Task PostForgotPasswordAsync(ForgotPasswordViewModel model, string callbackurl);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<string> CreateCodeAsync(AppUser user);
    }
}
