using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Blog.Commands.RemoveCategory;
using S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Interfaces.FacadPatterns
{
	public interface IBlogFacad
	{
	    AddNewCategoryService AddNewCategoryService { get; }
    	IGetAllCategoriesService GetAllCategoriesService { get; }
		IRemoveCategoryService RemoveCategoryService { get; }
	}

}
