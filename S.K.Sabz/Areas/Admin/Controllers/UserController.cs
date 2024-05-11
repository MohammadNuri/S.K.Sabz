using Microsoft.AspNetCore.Mvc;
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
            return View(_userFacad.GetAllUsersService.Execute(new RequestUserDto
            {
                Page = page,
                SearchKey = searchKey    
            }));
        }



    }
}
