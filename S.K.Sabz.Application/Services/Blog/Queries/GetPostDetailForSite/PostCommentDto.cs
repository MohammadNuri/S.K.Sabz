namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostDetailForSite
{
    public partial class GetPostDetailForSiteService
    {
        public class PostCommentDto
        {
            public long Id { get; set; }
            public string Text { get; set; } = string.Empty;
            public DateTime InsertTime { get; set; }
            public string UserName { get; set; } = string.Empty;
            public List<PostCommentDto> Replies { get; set; } = new List<PostCommentDto>();
        }
    }
}
