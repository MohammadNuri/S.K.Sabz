namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin
{
	public class PostForAdminList_Dto
	{
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int ViewCount { get; set; }
		public List<PostImageDto> Images { get; set; }
	}
}
