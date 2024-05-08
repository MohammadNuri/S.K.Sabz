using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostById
{
	public class GetPostById : IGetPostById
	{
		private readonly IDataBaseContext _context;
        public GetPostById(IDataBaseContext context)
        {
			_context = context;

		}

		public ResultDto<PostDataDto> Execute(long postId)
		{
			var post = _context.Posts
				.Include(p => p.PostImages)
				.FirstOrDefault(p => p.Id == postId);

			if (post == null)
			{
				return new ResultDto<PostDataDto>
				{
					Data = null,
					IsSuccess = false,
					Message = "پست پیدا نشد"
				};
			}

			var postDataDto = new PostDataDto
			{
				Title = post.Title,
				Slug = post.Slug,
				Position = post.Position,
				IsSpecial = post.IsSpecial,
				Displayed = post.Displayed,
				CategoryId = post.CategoryId,
				Description = post.Description,
				Images = post.PostImages.Select(image => new PostImageDto
				{
					Id = image.Id,
					Src = image.Src
				}).ToList()
			};

			return new ResultDto<PostDataDto>
			{
				Data = postDataDto,
				IsSuccess = true,
				Message = "پست با موفقیت پیدا شد"
			};
		}
	}
}
