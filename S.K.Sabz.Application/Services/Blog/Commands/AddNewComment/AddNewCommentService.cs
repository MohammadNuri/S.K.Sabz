using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewComment
{
	public class AddNewCommentService : IAddNewCommentService
	{

		private readonly IDataBaseContext _context;
        public AddNewCommentService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ExecuteAsync(AddNewCommentDto request, long userId, long postId, long? parentCommentId)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "لطفا برای نظر خود متنی وارد کنید"
                };
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر پیدا نشد"
                };
            }

            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "پست مورد نظر پیدا نشد"
                };
            }

            // Check if this comment is a reply
            if (parentCommentId.HasValue)
            {
                var parentCommentExists = await _context.PostComments.AnyAsync(c => c.Id == parentCommentId);
                if (!parentCommentExists)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "نظر والد مورد نظر پیدا نشد"
                    };
                }
            }

            var postComment = new PostComment()
            {
                Text = request.Text,
                PostId = postId, // Set the PostId to link this comment to the specific post
                Post = post,     // Set the Post navigation property
                UserId = userId, // Set the UserId to link this comment to the user
                User = user,     // Set the User navigation property
                ParentCommentId = parentCommentId // Set the ParentCommentId for replies (if applicable)
            };

            _context.PostComments.Add(postComment);
            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "نظر با موفقیت ثبت شد"
            };
        }

    }
}
