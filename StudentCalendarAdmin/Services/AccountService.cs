﻿using Microsoft.AspNetCore.Identity;
using StudentCalendarAdmin.Interfaces;
using StudentCalendarAdmin.IServices;
using Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Extensions;
using StudentCalendarAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCalendarAdmin.Models;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace StudentCalendarAdmin.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISendGridEmail _sendGridEmail;
        private readonly RoleManager<IdentityRole> _roleManager;
 
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ISendGridEmail sendGridEmail, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sendGridEmail = sendGridEmail;
            _roleManager = roleManager;
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

            if (user != null && user.EmailConfirmed && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserEmail, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    user.LoginTime = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                    return result;
                }
            }

            return SignInResult.Failed;

        }

        public async Task PostLogOffAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterViewModel> GetRegisterAsync(string returnUrl)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.ReturnUrl = returnUrl;
            return registerViewModel;
        }

        public async Task<bool> PostRegisterAsync(RegisterViewModel registerViewModel)
        {
            
            var user = new AppUser { Email = registerViewModel.Email, FirstName = registerViewModel.FirstName, LastName = registerViewModel.LastName, IdGroup = 0, UserName = registerViewModel.Email};
            user.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)                            
                return true;
            
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
