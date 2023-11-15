using Microsoft.AspNetCore.Identity;
using StudentCalendar.Interfaces;
using StudentCalendar.IServices;
using Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Extensions;
using StudentCalendar.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCalendar.Models;

namespace StudentCalendar.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISendGridEmail _sendGridEmail;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGroupService _groupService;
        public AccountService(IGroupService groupService,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ISendGridEmail sendGridEmail, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sendGridEmail = sendGridEmail;
            _roleManager = roleManager;
            _groupService = groupService;
        }

        public string GetResetPassword(string currentUrl)
        {            
            string userId="";
            string pattern = @"userId=([^&]+)";
            Match match = Regex.Match(currentUrl, pattern);
            if (match.Success)
            {
                userId = match.Groups[1].Value;

            }
            var emailUser = _userManager.Users.First(c => c.Id == userId).Email;
            
            return emailUser ?? throw new ArgumentNullException(nameof(emailUser));
        }

        

        public async Task<IdentityResult> PostResetPasswordAsync(ResetPasswordViewModel resetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if(user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                return result;
            }
            throw new ArgumentNullException();
        }

        public async Task<SignInResult> PostLogin(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.UserEmail);

            if (user != null && !user.EmailConfirmed)
            {
                return SignInResult.Failed; 
            }
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserEmail, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {                
                if(user != null)
                {
                    user.LoginTime = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                }                
            }
            return result;
        }

        public async Task PostLogOffAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterViewModel> GetRegisterAsync(string returnUrl)
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            List<SelectListItem> listItems = new List<SelectListItem>();
            var groups = await _groupService.GetGroupsAsync();
            foreach (var group in groups)
            {
                listItems.Add(new SelectListItem { Value = group.Id.ToString(), Text = group.Name});
            }            
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.ReturnUrl = returnUrl;
            registerViewModel.Groups = listItems;
            return registerViewModel;
        }

        public async Task<bool> PostRegisterAsync(RegisterViewModel registerViewModel)
        {
            
            var user = new AppUser { Email = registerViewModel.Email, FirstName = registerViewModel.FirstName, LastName = registerViewModel.LastName, IdGroup = Convert.ToInt32(registerViewModel.GroupSelected), UserName = registerViewModel.Email};
            var result = new IdentityResult();
            //Only the first user will be an admin
            if (_userManager.Users.Count() < 2)
            {
                user.EmailConfirmed = true;
                result = await _userManager.CreateAsync(user, registerViewModel.Password);
                await _userManager.AddToRoleAsync(user, "Admin");          
            }
            else
            {
                if(user.IdGroup != 0)
                {
                    result = await _userManager.CreateAsync(user, registerViewModel.Password);
                    await _userManager.AddToRoleAsync(user, "User");

                }
                
            }
            if (result.Succeeded)
            {
                
                return true;
            }
            return false;
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email)?? throw new ArgumentNullException();
        }

        public async Task PostForgotPasswordAsync(ForgotPasswordViewModel model,string callbackurl)
        {
            await _sendGridEmail.SendEmailAsync(model.Email, "Reset Email Confirmation", "Please reset email by going to this " +
                    "<a href=\"" + callbackurl + "\">link</a>");
        }

        public async Task<string> CreateCodeAsync(AppUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);

        }
    }
}
