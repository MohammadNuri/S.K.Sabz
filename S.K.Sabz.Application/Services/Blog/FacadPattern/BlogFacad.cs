using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Blog.Commands.RemoveCategory;
using S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.FacadPattern
{
	
	public class BlogFacad : IBlogFacad
	{
		//--Inject DataBase
		private readonly IDataBaseContext _context;
		public BlogFacad(IDataBaseContext context)
		{
			_context = context;
		}


		//--Inject AddNewCategoryService
		private AddNewCategoryService _addNewCategory;
		public AddNewCategoryService AddNewCategoryService
		{
			get
			{
				return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
			}
		}

		private IGetAllCategoriesService _getAllCategoriesService;
		public IGetAllCategoriesService GetAllCategoriesService
		{
			get
			{
				return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
			}
		}

		private IRemoveCategoryService _removeCategoryService;
		public IRemoveCategoryService RemoveCategoryService
		{
			get
			{
				return _removeCategoryService = _removeCategoryService ?? new RemoveCategoryService(_context);
			}
		}

	}
}
