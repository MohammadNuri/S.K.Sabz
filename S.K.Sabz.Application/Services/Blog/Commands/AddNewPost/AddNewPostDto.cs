using Microsoft.AspNetCore.Http;
using S.K.Sabz.Domain.Entities.Blog;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewPost
{
	public class AddNewPostDto
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Slug { get; set; } = string.Empty;
		public bool Displayed { get; set; }
		public bool IsSpecial { get; set; }
		public long CategoryId { get; set; }
		public List<IFormFile> Images { get; set; }
        public Position Position { get; set; }
    }
}
