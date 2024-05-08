namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin
{
	public class PostForAdminDto
	{
		public int RowCount { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }

		public List<PostForAdminList_Dto> Posts { get; set; }
    }
}
