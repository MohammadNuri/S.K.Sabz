using Microsoft.AspNetCore.Http;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Common;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.EditPost
{
	public class EditPostService : IEditPostService
	{
		private readonly IDataBaseContext _context;
		public EditPostService(IDataBaseContext context)
		{
			_context = context;
		}

		public ResultDto Execute(EditPostDto request)
		{
			var post = _context.Posts.Find(request.PostId);

			if (post == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "پست پیدا نشد"
				};
			}

			// Update post properties
			post.Title = request.Title;
			if (request.Description == "<p><br></p>")
			{
				request.Description = post.Description;
			}
			post.Description = request.Description;
			post.Slug = request.Slug;
			post.Displayed = request.Displayed;
			post.IsSpecial = request.IsSpecial;
			post.CategoryId = request.CategoryId;
			post.Position = request.Position;
			post.UpdateTime = DateTime.Now;

			// Handle new images
			AddNewImagesToPost(post, request.NewImages);

			// Handle image removal
			RemoveImagesFromPost(post, request.RemovedImageIds);

			try
			{
				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = "ویرایش با موفقیت انجام شد"
				};
			}
			catch (Exception ex)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "لطفا دسته بندی را انتخاب کنید"
				};
			}

		}

		private void AddNewImagesToPost(Post post, List<IFormFile> newImages)
		{
			if (newImages != null && newImages.Count > 0)
			{
				var uploadFileService = new UploadFileService("wwwroot/PostImages");
				var uploadedResults = uploadFileService.UploadFiles(newImages);

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
			}
		}

		private void RemoveImagesFromPost(Post post, List<long> removedImageIds)
		{
			if (removedImageIds != null && removedImageIds.Count > 0)
			{
				foreach (var removedImageId in removedImageIds)
				{
					var imageToRemove = post.PostImages.FirstOrDefault(pi => pi.Id == removedImageId);
					if (imageToRemove != null)
					{
						_context.PostImages.Remove(imageToRemove);
					}
				}
			}
		}

	}
}
