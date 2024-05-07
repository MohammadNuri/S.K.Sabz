using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory
{
	public class AddNewCategoryService : IAddNewCategoryService
	{
		private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context; 
        }


        public ResultDto Execute(long? ParentId, string Name)
        {
			if (string.IsNullOrEmpty(Name))
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "نام دسته بندی را وارد کنید"
				};
			}

			Category category = new Category()
			{
				Name = Name,
			    Parent = GetParent(ParentId)
			};
			_context.Categories.Add(category);
			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "دسته بندی با موفقیت اضافه شد"
			};

		}
		private Category GetParent(long? parentId)
		{
			return _context.Categories.Find(parentId);
		}

	}
}
