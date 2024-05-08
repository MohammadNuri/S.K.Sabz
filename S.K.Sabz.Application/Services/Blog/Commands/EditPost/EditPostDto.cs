using Microsoft.AspNetCore.Http;
using S.K.Sabz.Domain.Entities.Blog;

namespace S.K.Sabz.Application.Services.Blog.Commands.EditPost
{
	public class EditPostDto
	{
		public long PostId { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Slug { get; set; } = string.Empty;
		public bool Displayed { get; set; }
		public bool IsSpecial { get; set; }
		public long CategoryId { get; set; }
		public List<IFormFile> NewImages { get; set; } // For newly added images
		public List<long> RemovedImageIds { get; set; } // For removed image IDs
		public Position Position { get; set; }

	}
}
