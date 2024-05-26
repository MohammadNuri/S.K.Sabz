using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewComment;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite;
using S.K.Sabz.Domain.Entities.Blog;
using System.Security.Claims;

namespace S.K.Sabz.Controllers
{
    public class BlogListController : Controller
    {
        private readonly IBlogFacad _blogFacad;
        public BlogListController(IBlogFacad blogFacad)
        {
            _blogFacad = blogFacad;
        }
        public IActionResult Index(string? searchKey, long? catId, Ordering ordering = Ordering.theNewest, int page = 1, int pageSize = 20, bool isSpecial = false, Position position = Position.Main, bool topPost = false)
        {
            return View(_blogFacad.GetPostForSiteService.Execute(ordering, searchKey, catId, page, pageSize, isSpecial, position,topPost).Data);
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


        [HttpPost]
        public async Task<IActionResult> AddNewComment(AddNewCommentDto request, long postId, long? parentCommentId)
        {

			var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (!long.TryParse(userIdString, out long userId))
			{
				return Ok();
			}


            var result = await _blogFacad.AddNewCommentService.ExecuteAsync(request, userId, postId, parentCommentId);

			return Json(result);
        }

    }
}
