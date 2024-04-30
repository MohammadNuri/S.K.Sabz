using S.K.Sabz.Application.Services.Blog.Queries.GetCategories;
using S.K.Sabz.Common.Dto;

namespace S.K.Sabz.Application.Services.Blog.Queries.GetCategories
{
	public interface IGetCategoryService
    {
        ResultDto<List<CategoriesDto>> Execute(long? parentId);
    }
}
