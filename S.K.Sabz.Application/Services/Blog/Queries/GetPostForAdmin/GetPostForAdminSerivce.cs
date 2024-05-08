using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin
{
	public class GetPostForAdminSerivce : IGetPostForAdminSerivce
	{
		private readonly IDataBaseContext _context;
        public GetPostForAdminSerivce(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<PostForAdminDto> Execute(int page = 1, int pageSize = 20)
		{
			int rowCount = 0;

            var posts = _context.Posts
                .Include(p => p.Category)
                .Include(p => p.PostImages)
                .ToPaged(page, pageSize, out rowCount)
                .Select(p => new PostForAdminList_Dto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    ViewCount = p.ViewCount,
                    Images = p.PostImages.Select(pi => new PostImageDto
                    {
                        Id = pi.Id,
                        Src = pi.Src,
                    }).ToList()

                }).ToList();

            return new ResultDto<PostForAdminDto>()
            {
                Data = new PostForAdminDto()
                {
                    Posts = posts,
                    CurrentPage = page,
                    PageSize = pageSize,
                    RowCount = rowCount,
                },
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد"
            };
        }
    }
}
