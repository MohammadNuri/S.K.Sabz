using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewComment;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewPost;
using S.K.Sabz.Application.Services.Blog.Commands.DeleteComment;
using S.K.Sabz.Application.Services.Blog.Commands.EditPost;
using S.K.Sabz.Application.Services.Blog.Commands.RemoveCategory;
using S.K.Sabz.Application.Services.Blog.Commands.RemovePost;
using S.K.Sabz.Application.Services.Blog.Queries.GetAllCategories;
using S.K.Sabz.Application.Services.Blog.Queries.GetCategories;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostById;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostDetailForSite;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin;
using S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite;
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


		//--Inject Services
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

		private IGetPostForAdminSerivce _getPostForAdmin;
		public IGetPostForAdminSerivce GetPostForAdminSerivce
		{
			get
			{
				return _getPostForAdmin = _getPostForAdmin ?? new GetPostForAdminSerivce(_context);
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


		private IGetCategoryService _getCategory;
		public IGetCategoryService GetCategoryService
		{
			get
			{
				return _getCategory = _getCategory ?? new GetCategoryService(_context);
			}
		}

		private IGetPostById _getPostById;
		public IGetPostById GetPostById
		{
			get
			{
				return _getPostById = _getPostById ?? new GetPostById(_context);
			}
		}
        private IGetPostForSiteService _getPostForSiteService;
        public IGetPostForSiteService GetPostForSiteService
        {
            get
            {
                return _getPostForSiteService = _getPostForSiteService ?? new GetPostForSiteService(_context);
            }
        }
        private IGetPostDetailForSiteService _getPostDetailForSite;
        public IGetPostDetailForSiteService GetPostDetailForSiteService
        {
            get
            {
                return _getPostDetailForSite = _getPostDetailForSite ?? new GetPostDetailForSiteService(_context);
            }
        }
        


        private AddNewPostService _addNewPostService;
		public AddNewPostService AddNewPostService
		{
			get
			{
				return _addNewPostService = _addNewPostService ?? new AddNewPostService(_context);
			}
		}

		private RemovePostService _removePost;
		public RemovePostService RemovePostService
		{
			get
			{
				return _removePost = _removePost ?? new RemovePostService(_context);
			}
		}

		private EditPostService _editPost;
		public EditPostService EditPostService
		{
			get
			{
				return _editPost = _editPost ?? new EditPostService(_context);
			}
		}

		private AddNewCommentService _addNewCommentService;
		public AddNewCommentService AddNewCommentService
		{
			get
			{
				return _addNewCommentService = _addNewCommentService ?? new AddNewCommentService(_context);
			}
		}

        private DeleteCommentService _deleteCommentService;
        public DeleteCommentService DeleteCommentService
        {
            get
            {
                return _deleteCommentService = _deleteCommentService ?? new DeleteCommentService(_context);
            }
        }

        




    }
}
