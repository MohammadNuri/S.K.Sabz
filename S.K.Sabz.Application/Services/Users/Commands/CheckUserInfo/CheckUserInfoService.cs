using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Users.Commands.UpdateUserInfo;
using S.K.Sabz.Application.Services.Users.Queries.GetUserById;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.CheckUserInfo
{
    public class CheckUserInfoService : ICheckUserInfoService
    {
        private readonly IUserFacad _userFacad;
        public CheckUserInfoService(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }


        public async Task<ResultDto<UserInfoDto>> CheckUserInfoAsync(long userId)
        {
            var user = await _userFacad.GetUserById.GetUserByIdAsync(userId);

            if (user.FirstName == "" && user.LastName == "")
            {
                return new ResultDto<UserInfoDto>() { IsSuccess = false , Message = "نام و نام کاربری وجود ندارد" };
            }


            return new ResultDto<UserInfoDto>()
            {
                IsSuccess = true ,
                Message = "نام و نام کاربری وجود دارد",
                Data = new UserInfoDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
			};

        }
    }
}
