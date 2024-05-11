using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite
{
    public class GetPostForSiteService : IGetPostForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetPostForSiteService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto<PostForSiteDto> Execute(Ordering ordering, string? searchKey, long? catId, int page, int pageSize, bool isSpecial, Position position,bool topPost)
        {
            int totalRow = 0;
            var postQuery = _context.Posts
                .Include(c => c.PostImages)
                .Include(c => c.User)
                .AsQueryable();

            if (catId != null)
            {
                postQuery = postQuery.Where(c => c.CategoryId == catId || c.Category.ParentId == catId).AsQueryable();
            }

            if (isSpecial)
            {
                postQuery = postQuery.Where(c => c.IsSpecial).AsQueryable();
            }

            if (!string.IsNullOrEmpty(searchKey))
            {
                postQuery = postQuery.Where(c => c.Title.Contains(searchKey)).AsQueryable();
            }

            if (topPost)
            {
                postQuery = postQuery.Where(c => c.Position == Position.TopWide);
            }
            else if (position != Position.Main)
            {
                postQuery = postQuery.Where(c => c.Position == position);
            }

            switch (ordering)
            {
                case Ordering.NotOrder:
                    postQuery = postQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    postQuery = postQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.MostPopular:
                    postQuery = postQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.theNewest:
                    postQuery = postQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
            }

            var post = postQuery.ToPaged(page, pageSize, out totalRow);

            return new ResultDto<PostForSiteDto>()
            {
                Data = new PostForSiteDto
                {
                    TotalRow = totalRow,
                    Posts = post.Select(c => new PostForSite_Dto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Displayed = c.Displayed,
                        IsSpecial = c.IsSpecial,
                        Position = c.Position,
                        ViewCount = c.ViewCount,
                        ImageSrc = c.PostImages.LastOrDefault().Src,
                        UserId = c.UserId,
                        Description = c.Description,
                        InsertTime = c.InsertTime,
                        UserName = $"{c.User.FirstName} {c.User.LastName}",
                    }).ToList(),
                },
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد"
            };

        }

    }
}
