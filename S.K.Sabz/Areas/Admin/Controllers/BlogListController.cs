using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewPost;
using S.K.Sabz.Application.Services.Blog.Commands.EditPost;
using S.K.Sabz.Application.Services.Common.ErrorHandling;
using S.K.Sabz.Common;
using S.K.Sabz.Common.Dto;
using System.Security.Claims;

namespace S.K.Sabz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogListController : Controller
    {
        private readonly IBlogFacad _blogFacad;
        public BlogListController(IBlogFacad blogFacad)
        {
            _blogFacad = blogFacad;
        }

        public IActionResult Index(int page = 1, int pageSize = 20)
		{
            return View(_blogFacad.GetPostForAdminSerivce.Execute(page, pageSize).Data);
        }

		public IActionResult Detail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddNewPost()
        {
			// Fetch categories from the service
			var categories = _blogFacad.GetAllCategoriesService.Execute().Data;

			// Convert categories to SelectListItems
			var categoryItems = categories.Select(c => new SelectListItem
			{
				Value = c.Id.ToString(), // Assuming Id is a long or int
				Text = c.Name
			});

			// Store the SelectListItems in ViewBag
			ViewBag.Categories = categoryItems;
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddNewPost(AddNewPostDto request)
		{
			var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (!long.TryParse(userIdString, out long userId))
			{
				return Ok();
			}

			List<IFormFile> images = new List<IFormFile>();
			for (int i = 0; i < Request.Form.Files.Count; i++)
			{
				var file = Request.Form.Files[i];
				images.Add(file);
			}

			request.Images = images;

			// Execute asynchronously
			var result = await _blogFacad.AddNewPostService.ExecuteAsync(request, userId);
			return Json(result);


		}

		[HttpGet]
		public IActionResult GetPostData(long postId)
		{

			var result = _blogFacad.GetPostById.Execute(postId);

			return Json(result);
		}

		[HttpGet]
		public IActionResult EditPost(long postId)
		{
			var result = _blogFacad.GetPostById.Execute(postId);

			if (result.IsSuccess)
			{
				var post = result.Data;

				var categories = _blogFacad.GetAllCategoriesService.Execute().Data;

				// Convert categories to SelectListItems
				var categoryItems = categories.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(), // Assuming Id is a long or int
					Text = c.Name
				});

				// Store the SelectListItems and the fetched post data in ViewBag
				ViewBag.Categories = categoryItems;
				ViewBag.PostData = post;
				ViewBag.HtmlContent = post.Description;

				return View();
			}
			else
			{
				// Handle error if the post data retrieval was unsuccessful
				return RedirectToAction("Index", "BlogList"); // Redirect to a suitable action or page
			}
		}

		[HttpPost]
		public IActionResult EditPost(EditPostDto request)
		{
			var result = _blogFacad.EditPostService.Execute(request);
			return Json(result);
		}

		[HttpPost]
		public IActionResult RemovePost(long postId)
		{
			var result = _blogFacad.RemovePostService.Execute(postId);
			return Json(result);
		}
	}
}
