using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Common.Roles;

namespace S.K.Sabz.Areas.Admin.Controllers
{
	[Authorize(Policy = UserRoles.Admin)]
	[Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserFacad _userFacad;
        public UserController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        public IActionResult Index(string? searchKey, int page = 1, int pageSize = 20)
        {
			// Retrieve all request headers
			var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

			ViewBag.Ip = ipAddress;

			return View(_userFacad.GetAllUsersService.Execute(searchKey,page,pageSize));
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
