using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Common;
using S.K.Sabz.Application.Services.Common.ErrorHandling;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewPost
{
	public class AddNewPostService : IAddNewPostService
	{


		private readonly IDataBaseContext _context;
        public AddNewPostService(IDataBaseContext context)
        {
            _context = context;
        }

		public async Task<ResultDto> ExecuteAsync(AddNewPostDto request, long userId)
		{
			var user = await _context.Users.FindAsync(userId);
			if (user == null)
			{
				return new ResultDto
				{
					IsSuccess = false,
					Message = "کاربر پیدا نشد"
				};
			}

			var category = await _context.Categories.FindAsync(request.CategoryId);

			if (category == null)
			{
				// Log or handle the situation where the category is not found
				// For example, you can throw a custom exception, log an error, or take another appropriate action
				// In this case, we'll just log a message and continue with the process
				Console.WriteLine("دسته بندی پیدا نشد " + request.CategoryId);
			}


			var post = new Post()
			{
				Title = request.Title,
				Description = request.Description,
				Displayed = request.Displayed,
				IsSpecial = request.IsSpecial,
				Slug = request.Slug,
				Position = request.Position,
				Category = category,
				User = user
			};

			_context.Posts.Add(post);

			var uploadFileService = new UploadFileService("wwwroot/PostImages");
			var uploadedResults = uploadFileService.UploadFiles(request.Images);

			// Add Post Images
			var postImages = new List<PostImages>();
			foreach (var uploadedResult in uploadedResults)
			{
				postImages.Add(new PostImages
				{
					Post = post,
					Src = uploadedResult.FileNameAddress
				});
			}

			_context.PostImages.AddRange(postImages);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{

			}

			return new ResultDto { IsSuccess = true, Message = "پست با موفقیت اضافه شد" };

		}

	}
}
