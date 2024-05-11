using Microsoft.AspNetCore.Mvc;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Models;
using S.K.Sabz.Models.BlogHomePage;
using System.Diagnostics;

namespace S.K.Sabz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogFacad _blogFacad;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogFacad blogFacad)
        {
            _logger = logger;
            _blogFacad = blogFacad;
        }

        public IActionResult Index()
        {
            // Retrieve top wide posts
            var topWidePosts = _blogFacad.GetPostForSiteService.Execute(Ordering.MostPopular, null, null, 1, 3, false, Position.TopWide,true).Data.Posts;

            // Retrieve special posts
            var specialPosts = _blogFacad.GetPostForSiteService.Execute(Ordering.theNewest, null, null, 1, 3, true, Position.Main, false).Data.Posts;

            // Retrieve recent posts
            var recentPosts = _blogFacad.GetPostForSiteService.Execute(Ordering.theNewest, null, null, 1, 3, false, Position.Main, false).Data.Posts;

            // Retrieve middle wide post
            var middleWidePost = _blogFacad.GetPostForSiteService.Execute(Ordering.theNewest, null, null, 1, 1, false, Position.CenterWide, false).Data.Posts;

            // Retrieve all posts (assuming you need this for some section)
            var allPosts = _blogFacad.GetPostForSiteService.Execute(Ordering.theNewest, null, null, 1, 6, false, Position.Main, false).Data.Posts;

            // Create the view model
            var viewModel = new HomePageViewModel
            {
                TopWidePosts = topWidePosts.ToList(),
                SpecialPosts = specialPosts.ToList(),
                RecentPosts = recentPosts.ToList(),
                MiddleWidePost = middleWidePost.ToList(),
                AllPosts = allPosts.ToList()
            };

            // Pass the view model to the view
            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }
}