using S.K.Sabz.Domain.Entities.Blog;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite
{
    public class PostForSite_Dto
	{
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
		public int ViewCount { get; set; }
		public bool IsSpecial { get; set; }
		public Position Position { get; set; }
		public bool Displayed { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
