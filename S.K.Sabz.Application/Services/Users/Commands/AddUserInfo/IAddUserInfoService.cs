using S.K.Sabz.Application.Services.Users.Commands.UpdateUserInfo;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.AddUserInfo
{
    public interface IAddUserInfoService
    {
        Task<ResultDto> UpdateUserInfoExecuteAsync(int userId, UserInfoDto userInfo);

    }
}
