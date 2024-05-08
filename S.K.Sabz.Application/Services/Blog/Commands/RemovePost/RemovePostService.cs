using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.RemovePost
{
	public class RemovePostService : IRemovePostService
	{
		private readonly IDataBaseContext _context;
		public RemovePostService(IDataBaseContext context)
		{
			_context = context;
		}

		public ResultDto Execute(long postId)
		{
			var post = _context.Posts.Find(postId);
			if (post == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "پست پیدا نشد"
				};
			}

			post.IsRemoved = true;
			post.RemoveTime = DateTime.Now;

			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "پست با موفقیت حذف شد"
			};
		}
	}
}
