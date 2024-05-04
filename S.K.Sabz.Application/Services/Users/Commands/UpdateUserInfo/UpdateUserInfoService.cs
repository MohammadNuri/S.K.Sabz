using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.UpdateUserInfo
{
    public class UpdateUserInfoService : IUpdateUserInfoService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserInfoService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> UpdateUserInfoAsync(long userId, UserInfoDto userInfo)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                // Handle the case where the user with the specified ID is not found
                return new ResultDto { IsSuccess = false, Message = $"User with ID {userId} not found" };
            }

            // Update the user's FirstName and LastName properties
            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;

            await _context.SaveChangesAsync();

            return new ResultDto { IsSuccess = true, Message = "با موفقیت ثبت شد" };
        }

    }
}
