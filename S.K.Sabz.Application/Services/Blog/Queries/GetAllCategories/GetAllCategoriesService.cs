using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Blog.Queries.GetCategories;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories
{
	public class GetAllCategoriesService : IGetAllCategoriesService
	{
		private readonly IDataBaseContext _context;
        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context; 
        }


		public ResultDto<List<AllCategoriesDto>> Execute()
		{
			var parentCategories = _context.Categories
				.Include(p => p.ParentCategory)
				.Include(p => p.SubCategories)
				.Where(p => p.ParentCategory == null) // Filter only parent categories
				.ToList()
				.Select(p => new AllCategoriesDto
				{
					Id = p.Id,
					Name = p.Name,
					ChildCategories = p.SubCategories.Select(c => new CategoriesDto
					{
						Id = c.Id,
						Name = c.Name,
						Parent = new ParentCategoryDto // Set parent category for child
						{
							Id = p.Id,
							Name = p.Name
						},
						HasChild = c.SubCategories.Any()
					}).ToList()
				}).ToList();

			return new ResultDto<List<AllCategoriesDto>>
			{
				Data = parentCategories,
				IsSuccess = true,
				Message = "لیست باموقیت برگشت داده شد"
			};
		}

	}
}
