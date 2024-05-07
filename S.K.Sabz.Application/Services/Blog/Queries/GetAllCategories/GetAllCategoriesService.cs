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
			var categories = _context
				.Categories
				.Include(p => p.Parent)
				.Where(p => p.ParentId != null && p.Parent !=null )
				.ToList()
				.Select(p => new AllCategoriesDto
				{
					Id = p.Id,
					Name = $"{p.Parent.Name} - {p.Name}",
				}
				).ToList();

			return new ResultDto<List<AllCategoriesDto>>
			{
				Data = categories,
				IsSuccess = true,
				Message = "",
			};
		}

	}
}
