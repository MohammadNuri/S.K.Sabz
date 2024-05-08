using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostDetailForSite
{
    public class GetPostDetailForSiteService : IGetPostDetailForSiteService
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
                    Title = post.Title,
                    Description = post.Description,
                    ViewCount = post.ViewCount,
                    Category = $"{post.Category.Parent.Name} - {post.Category.Name}",
                    Images = post.PostImages.Select(p => p.Src).ToList(),
                    InsertTime = post.InsertTime,
                    UserId = post.UserId,
                    UserName = $"{post.User.FirstName} {post.User.LastName}",
                },
                IsSuccess = true,
                Message = "محصول با موفقیت برگشت داده شد"
            };
        }
    }
}
