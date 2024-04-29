using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory
{
	public interface IAddNewCategoryService
	{
		ResultDto Execute(long? ParentId, string Name);
	}
}
