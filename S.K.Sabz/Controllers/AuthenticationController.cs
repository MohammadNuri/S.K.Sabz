using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Models.AuthenticationViewModel;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Identity;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Users.Commands;
using Azure.Core;

namespace S.K.Sabz.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacad _userFacad;

        public AuthenticationController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || request.PhoneNumber.Length < 10 || request.PhoneNumber.Length > 13)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفاً شماره موبایل را به درستی وارد کنید" });
            }

            string phoneNumberRegex = @"^((0?9)|(\+?989))\d{9}$"; // Updated regex pattern
            if (!Regex.IsMatch(request.PhoneNumber, phoneNumberRegex))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شماره موبایل را به درستی وارد کنید" });
            }

            if (User.Identity.IsAuthenticated)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید مجدد وارد شوید" });
            }

            var loginDto = new LoginUserDto { PhoneNumber = request.PhoneNumber }; // Create a LoginUserDto object

            var userResult = _userFacad.LoginUserService.LoginExecute(loginDto); // Call the LoginExecute method

            if (userResult.IsSuccess)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Name, request.PhoneNumber),
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(principal, properties).Wait(); // Wait for the sign-in operation to complete
            }

            return Json(userResult);
        }

        public IActionResult UserInfo()
        {
            return View();
        }


    //    [HttpPost]
    //    public IActionResult UserInfo(UserInfoViewModel userInfo)
    //    {
    //        // Update user information in the database




    //        // Update claims
    //        var claims = new List<Claim>
    //{
    //    new Claim(ClaimTypes.NameIdentifier, userResult.Data.UserId.ToString()),
    //    new Claim(ClaimTypes.Name, request.PhoneNumber),
    //    new Claim(ClaimTypes.GivenName, userInfo.FirstName),
    //    new Claim(ClaimTypes.Surname, userInfo.LastName)
    //};

    //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //        var principal = new ClaimsPrincipal(identity);
    //        var properties = new AuthenticationProperties
    //        {
    //            IsPersistent = true
    //        };

    //        HttpContext.SignInAsync(principal, properties).Wait();

    //        return RedirectToAction("Index", "Home"); // Redirect to home page after updating info
    //    }

    //    public IActionResult CustomSignOut()
    //    {
    //        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    //        return RedirectToAction("Login", "Authentication");
    //    }

    }
}
