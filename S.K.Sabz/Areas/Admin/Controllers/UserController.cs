using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Users.Queries.GetAllUsers;

namespace S.K.Sabz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserFacad _userFacad;
        public UserController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
			// Retrieve all request headers
			var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

			ViewBag.Ip = ipAddress;

			return View(_userFacad.GetAllUsersService.Execute(new RequestUserDto
            {
                Page = page,
                SearchKey = searchKey    
            }));
        }

        [HttpPost]
        public IActionResult RemoveUser(long userId)
        {

            var result = _userFacad.RemoveUserService.Execute(userId);

            return Json(result);
        }

        [HttpPost]
        public IActionResult UserStatusChange(long userId)
        {

            var result = _userFacad.UserStatusChangeService.Execute(userId);
			return Json(result);
        }


		[HttpPost]
		public IActionResult MakeRoleAdmin(long userId)
		{
			var result = _userFacad.ChangeRoleService.MakeAdmin(userId);
			return Json(result);
		}

		[HttpPost]
		public IActionResult MakeRoleCustomer(long userId)
		{
			var result = _userFacad.ChangeRoleService.MakeCustomer(userId);
			return Json(result);
		}




	}
}
