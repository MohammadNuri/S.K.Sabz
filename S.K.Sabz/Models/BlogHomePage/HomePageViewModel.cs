using S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite;

namespace S.K.Sabz.Models.BlogHomePage
{
    public class HomePageViewModel
    {
        public List<PostForSite_Dto> TopWidePosts { get; set; }
        public List<PostForSite_Dto> SpecialPosts { get; set; }
        public List<PostForSite_Dto> RecentPosts { get; set; }
        public List<PostForSite_Dto> MiddleWidePost { get; set; }
        public List<PostForSite_Dto> AllPosts { get; set; }
    }
}
