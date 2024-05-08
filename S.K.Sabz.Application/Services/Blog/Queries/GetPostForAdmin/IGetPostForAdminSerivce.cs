using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForAdmin
{
	public interface IGetPostForAdminSerivce
	{
		ResultDto<PostForAdminDto> Execute(int page = 1, int pageSize = 20);
	}
}
