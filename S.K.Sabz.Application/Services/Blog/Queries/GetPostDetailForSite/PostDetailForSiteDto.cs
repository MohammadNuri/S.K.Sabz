namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostDetailForSite
{
    public class PostDetailForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime InsertTime { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public List<string> Images { get; set; }
    }


}
