using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands
{
	public interface IUpdateUserInfoService
	{
		Task<ResultDto> UpdateUserInfoAsync(long userId, UserInfoDto userInfo);
	}
}
