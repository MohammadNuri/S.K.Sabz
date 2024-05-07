using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Common;

namespace S.K.Sabz.Areas.Admin.Controllers
{

	[Area("Admin")]
	public class CategoriesController : Controller
	{
		private readonly IBlogFacad _blogFacad;

		public CategoriesController(IBlogFacad blogFacad)
		{
			_blogFacad = blogFacad;
		}

		public IActionResult Index(long? parentId)
		{

			var result = _blogFacad.GetCategoryService.Execute(parentId); // Call your service to get categories

			if (!result.IsSuccess)
			{
				// Handle potential errors (e.g., log the error)
				return View("Error"); // Or redirect to an error page
			}

			var categories = result.Data;

			return View(categories);
		}

		[HttpGet]
		public IActionResult AddNewCategory(long? parentId)
		{
			ViewBag.parentId = parentId;
			return View();
		}
		[HttpPost]
		public IActionResult AddNewCategory(long? ParentId, string Name)
		{

			var result = _blogFacad.AddNewCategoryService.Execute(ParentId, Name);
			return Json(result);
		}

		[HttpPost]
		public IActionResult DeleteCategory(long CatId)
		{
			var result = _blogFacad.RemoveCategoryService.Execute(CatId);
			return Json(result);
		}
	}
}
