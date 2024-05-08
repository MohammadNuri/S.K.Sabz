using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewPost;
using S.K.Sabz.Application.Services.Blog.Commands.EditPost;
using S.K.Sabz.Application.Services.Blog.Commands.RemoveCategory;
using S.K.Sabz.Application.Services.Blog.Commands.RemovePost;
using S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories;
using S.K.Sabz.Application.Services.Blog.Queries.GetCategories;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostById;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin;
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
		IGetPostForAdminSerivce GetPostForAdminSerivce { get; }
		IRemoveCategoryService RemoveCategoryService { get; }
		IGetCategoryService GetCategoryService { get; }
		AddNewPostService AddNewPostService { get; }
		RemovePostService RemovePostService { get; }
		EditPostService EditPostService { get; }
		IGetPostById GetPostById { get; }

	}

}
