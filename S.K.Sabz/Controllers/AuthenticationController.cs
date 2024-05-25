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
using S.K.Sabz.Application.Services.Users.Commands.CheckUserInfo;
using S.K.Sabz.Domain.Entities.Users;
using S.K.Sabz.Application.Services.Users.Queries.GetUserIdByPhoneNumber;
using S.K.Sabz.Application.Services.Users.Commands.AddUserInfo;
using S.K.Sabz.Application.Services.Users.Commands.LoginUser;
using S.K.Sabz.Application.Services.Users.Commands.UpdateUserInfo;
using System.Data;
using System.Linq;

namespace S.K.Sabz.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacad _userFacad;
        private readonly IAddUserInfoService _addUserInfoService;
        private readonly ICheckUserInfoService _checkUserInfoService;
		private readonly IGetUserIdByPhoneNumberSerivce _getUserIdByPhoneNumberService;

		public AuthenticationController(IUserFacad userFacad,
			IAddUserInfoService addUserInfoService,
			ICheckUserInfoService checkUserInfoService,
			IGetUserIdByPhoneNumberSerivce getUserIdByPhoneNumberSerivce)
		{
			_userFacad = userFacad;
			_addUserInfoService = addUserInfoService;
			_checkUserInfoService = checkUserInfoService;
			_getUserIdByPhoneNumberService = getUserIdByPhoneNumberSerivce;
		}

		[HttpGet]
        public IActionResult Login()
        {
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel request, long userId)
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

			// Create a LoginUserDto object
			var loginDto = new LoginUserDto
			{
				PhoneNumber = request.PhoneNumber,
				Roles = new List<RolesInLoginUserDto>()
				{
					new RolesInLoginUserDto
					{
						Id = 3
					}
				}
			}; 

            var userResult = await _userFacad.LoginUserService.LoginExecuteAsync(loginDto); // Call the LoginExecute method



			if (userResult.IsSuccess)
			{
				var loginUserDto = new LoginUserDto
				{
					PhoneNumber = request.PhoneNumber,
				};

				userId = await _getUserIdByPhoneNumberService.Execute(loginUserDto);

				var checkUserInfo = await _checkUserInfoService.CheckUserInfoAsync(userId);

				if (checkUserInfo.IsSuccess == false)
				{
					var roles = userResult.Data.Roles;

					var firstClaims = new List<Claim>
					{
					   new Claim(ClaimTypes.NameIdentifier, userResult.Data.UserId.ToString()),
					   new Claim(ClaimTypes.Name, request.PhoneNumber),
					};
					if (!string.IsNullOrWhiteSpace(roles))
					{
						// Split the roles and add them as claims
						var roleClaims = roles.Split(',').Select(role => new Claim(ClaimTypes.Role, role.Trim()));
						firstClaims.AddRange(roleClaims);
					}

					var firstIdentity = new ClaimsIdentity(firstClaims, CookieAuthenticationDefaults.AuthenticationScheme);
					var firstPrincipal = new ClaimsPrincipal(firstIdentity);
					var firstProperties = new AuthenticationProperties
					{
						IsPersistent = true
					};

					HttpContext.SignInAsync(firstPrincipal, firstProperties).Wait();

					return Json(userResult);
				}
				else
				{
					var roles = userResult.Data.Roles;
					var claims = new List<Claim>
					 {
					  new Claim(ClaimTypes.NameIdentifier, userResult.Data.UserId.ToString()),
					  new Claim(ClaimTypes.Name, request.PhoneNumber),
					  new Claim(ClaimTypes.GivenName, checkUserInfo.Data.FirstName),
					  new Claim(ClaimTypes.Surname, checkUserInfo.Data.LastName),
						 };
					if (!string.IsNullOrWhiteSpace(roles))
					{
						// Split the roles and add them as claims
						var roleClaims = roles.ToString().Split(',')
							.Select(role => new Claim(ClaimTypes.Role, role.Trim()));

						claims.AddRange(roleClaims);
					}
					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);
					var properties = new AuthenticationProperties
					{
						IsPersistent = true
					};
					HttpContext.SignInAsync(principal, properties).Wait();
				}
            }

            return Json(userResult);
        }

        public IActionResult UserInfo()
        {
            return View();
        }


        [HttpPost]
		public async Task<IActionResult> UpdateUserInfoAsync(UserInfoViewModel userInfo)
		{
			// Get the user ID from the authenticated user's claims
			var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
			{
				// Handle the case where the user ID is not found or cannot be parsed
				// For simplicity, let's assume a generic error message for now
				return View("Error");
			}

			// Convert UserInfoViewModel to UserInfoDto
			var userInfoDto = new UserInfoDto
			{
				FirstName = userInfo.FirstName,
				LastName = userInfo.LastName
				// Assign other properties as needed
			};

			// Update user information in the database
			var updateUserInfoResult = await _addUserInfoService.UpdateUserInfoExecuteAsync(userId, userInfoDto);

			// Check if the update was successful
			if (!updateUserInfoResult.IsSuccess)
			{
				// Handle the case where the update failed, maybe return an error view
				// For simplicity, let's assume a generic error message for now
				return View("Error");
			}
			// Update claims

			var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userIdClaim.Value.ToString()),
            new Claim(ClaimTypes.Name, userIdClaim.Subject.Name),
            new Claim(ClaimTypes.GivenName, userInfo.FirstName),
            new Claim(ClaimTypes.Surname, userInfo.LastName)

        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            HttpContext.SignInAsync(principal, properties).Wait();

            return Json(updateUserInfoResult);
        }

        public IActionResult CustomSignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Authentication");
        }

		public IActionResult AccessDenied()
		{
            return RedirectToAction("Error", "Home", new { errorMessage = "شما به این بخش دسترسی ندارید!" });
        }

	}
}
