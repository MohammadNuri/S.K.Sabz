using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Models.AuthenticationViewModel;
using System.Text.RegularExpressions;

namespace S.K.Sabz.Controllers
{
	public class AuthenticationController : Controller
	{

		[HttpGet]
		public IActionResult Signup()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Signup(SignupViewModel request)
        {

            if (request.PhoneNumber <= 0)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا شماره موبایل را وارد کنید" });
            }


            string phoneNumberRegex = @"^((0?9)|(\+?989))\d{9}$"; // Updated regex pattern

            // Convert PhoneNumber to string before applying regex
            string phoneNumberStr = request.PhoneNumber.ToString();

            var match = Regex.Match(phoneNumberStr, phoneNumberRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شماره موبایل را به درستی وارد کنید" });
            }

            return View(match);
        }

    }
}
