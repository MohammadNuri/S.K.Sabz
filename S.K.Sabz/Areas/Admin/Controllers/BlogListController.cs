using Microsoft.AspNetCore.Mvc;

namespace S.K.Sabz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Detail()
        {
            return View();
        }


        public IActionResult AddNewPost()
        {
            return View();
        }

    }
}
