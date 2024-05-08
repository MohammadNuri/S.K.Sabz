using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetPostForSite
{
    public interface IGetPostForSiteService
	{
		ResultDto<PostForSiteDto> Execute(Ordering ordering, string? searchKey, long? catId, int page, int pageSize);
	}
}
