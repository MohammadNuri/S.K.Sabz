using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands
{
    public class AddUserInfoService : IAddUserInfoService
    {

        private readonly IUserFacad _userFacad;
        public AddUserInfoService(IUserFacad userFacad)
        {

            _userFacad = userFacad;
        }


        public async Task<ResultDto> UpdateUserInfoExecuteAsync(int userId, UserInfoDto userInfo)
        {

            var user = await _userFacad.GetUserById.GetUserByIdAsync(userId);

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            await _userFacad.UpdateUserInfoService.UpdateUserInfoAsync(userId, userInfo);

            return new ResultDto { IsSuccess = true, Message = "با موفقیت ثبت شد" };
        }
    }
}
