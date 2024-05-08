using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite;

namespace S.K.Sabz.Controllers
{
    public class BlogListController : Controller
    {
        private readonly IBlogFacad _blogFacad;
        public BlogListController(IBlogFacad blogFacad)
        {
            _blogFacad = blogFacad;
        }
        public IActionResult Index(Ordering ordering, string? searchKey, long? catId, int page = 1, int pageSize = 20)
        {
            return View(_blogFacad.GetPostForSiteService.Execute(ordering, searchKey, catId, page, pageSize).Data);
        }


        public IActionResult Detail(long Id)
        {
            var result = _blogFacad.GetPostDetailForSiteService.Execute(Id);
            if (!result.IsSuccess)
            {
                // Redirect to an error page or return a specific error view
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
            }

            return View(result.Data);
        }

    }
}
