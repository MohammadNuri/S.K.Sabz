using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostDetailForSite
{
    public partial class GetPostDetailForSiteService : IGetPostDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetPostDetailForSiteService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<PostDetailForSiteDto> Execute(long Id)
        {
            var post = _context.Posts
                .Include(c => c.Category)
                .ThenInclude(c => c.Parent)
                .Include(c => c.PostImages)
                .Include(c => c.User)
                .Include(c => c.PostComments)
                .ThenInclude(c => c.User)
                .FirstOrDefault(c => c.Id == Id);

            if (post == null)
            {
                return new ResultDto<PostDetailForSiteDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "پست پیدا نشد"
                };
            }


            post.ViewCount++;
            _context.SaveChanges();

            return new ResultDto<PostDetailForSiteDto>()
            {
                Data = new PostDetailForSiteDto()
                {
                    Id = Id,
                    Title = post.Title,
                    Description = post.Description,
                    ViewCount = post.ViewCount,
                    Category = $"{post.Category.Parent.Name} - {post.Category.Name}",
                    Images = post.PostImages.Select(p => p.Src).ToList(),
                    InsertTime = post.InsertTime,
                    UserId = post.UserId,
                    UserName = $"{post.User.FirstName} {post.User.LastName}",
                    PostComments = post.PostComments
                    .Where(c => c.ParentCommentId == null) //Only top-level comments
                    .Select(c => new PostCommentDto
                    {
                        Id= c.Id,
                        InsertTime = c.InsertTime,
                        Text = c.Text,
                        UserName = $"{c.User.FirstName} {c.User.LastName}",
                        Replies = c.Replies.Select(r => new PostCommentDto
                        {
                            Id = r.Id,
                            InsertTime= r.InsertTime,
                            Text= r.Text,
                            UserName = $"{r.User.FirstName} {r.User.LastName}",
                        }).ToList()
                    }).ToList()
                },
                IsSuccess = true,
                Message = "پست با موفقیت برگشت داده شد"
            };
        }
    }
}
