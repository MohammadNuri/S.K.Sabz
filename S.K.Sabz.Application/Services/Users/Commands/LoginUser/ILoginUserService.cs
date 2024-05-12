using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.LoginUser
{
    public interface ILoginUserService
    {
		Task<ResultDto<ResultUserDto>> LoginExecuteAsync(LoginUserDto request);
	}

}
