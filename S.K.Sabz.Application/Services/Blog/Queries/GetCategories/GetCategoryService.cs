using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Application.Services.Blog.Queries.GetCategories;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetCategories
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetCategoryService(IDataBaseContext context)
        {
            _context = context; 
        }

        public ResultDto<List<CategoriesDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories
               .Include(p => p.Parent)
               .Include(p => p.Children)
               .Where(p => p.ParentId == ParentId)
               .ToList()
               .Select(p => new CategoriesDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Parent = p.Parent != null ? new
                   ParentCategoryDto
                   {
                       Id = p.Parent.Id,
                       Name = p.Parent.Name,
                   }
                   : null,
                   HasChild = p.Children.Count() > 0 ? true : false,
               }).ToList();


            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };

        }
    }
}
