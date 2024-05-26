using S.K.Sabz.Application.Services.Blog.Commands.AddNewPost;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewComment
{
	public interface IAddNewCommentService
	{
		Task<ResultDto> ExecuteAsync(AddNewCommentDto request, long userId,long postId, long? parentCommentId);
	}
}
