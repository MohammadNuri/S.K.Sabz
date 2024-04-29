using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
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
			var categories = _context
				.Categories
				.Include(p => p.ParentCategory)
				.ToList()
				.Select(p => new AllCategoriesDto
				{
					Id = p.Id,
					Name = p.ParentCategory != null ? $"{p.ParentCategory.Name} - {p.Name}" : p.Name, // Handle null ParentCategory
				})
				.ToList();

			return new ResultDto<List<AllCategoriesDto>>
			{
				Data = categories,
				IsSuccess = true,
				Message = "",
			};
		}

	}
}
