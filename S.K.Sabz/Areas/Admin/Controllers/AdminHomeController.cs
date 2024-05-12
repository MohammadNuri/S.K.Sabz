using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Common.Roles;

namespace S.K.Sabz.Areas.Admin.Controllers
{
	[Authorize(Policy = UserRoles.Admin)]
	[Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
