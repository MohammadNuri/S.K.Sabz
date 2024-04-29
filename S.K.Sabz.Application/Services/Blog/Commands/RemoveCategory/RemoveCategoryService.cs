using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.RemoveCategory
{
	public class RemoveCategoryService : IRemoveCategoryService
	{
		private readonly IDataBaseContext _context;
		public RemoveCategoryService(IDataBaseContext context)
		{
			_context = context;
		}

		public ResultDto Execute(long CatId)
		{
			var category = _context.Categories.Find(CatId);
			if (category == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "دسته بندی پیدا نشد"
				};
			}
			category.IsRemoved = true;
			category.RemoveTime = DateTime.Now;
			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "دسته بندی با موفقیت حذف شد"

			};
		}
	}
}
