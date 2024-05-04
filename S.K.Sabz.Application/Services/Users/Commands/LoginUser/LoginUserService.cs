using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.LoginUser
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IDataBaseContext _context;
        public LoginUserService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto<ResultUserDto> LoginExecute(LoginUserDto request)
        {
            // Check if the user exists in the database
            var user = _context.Users
                .Where(p => p.PhoneNumber.Equals(request.PhoneNumber) && p.IsActive == true)
                .FirstOrDefault();

            if (user != null)
            {
                // User exists, execute login

                return new ResultDto<ResultUserDto>()
                {
                    Data = new ResultUserDto()
                    {
                        UserId = user.Id,
                        PhoneNumber = user.PhoneNumber
                    },
                    IsSuccess = true,
                    Message = "ورود به سایت با موفقیت انجام شد",
                };
            }
            else
            {
                // User does not exist, execute signup
                return SignUpExecute(request);
            }
        }

        public ResultDto<ResultUserDto> SignUpExecute(LoginUserDto request)
        {


            User user = new User()
            {
                PhoneNumber = request.PhoneNumber,
                IsActive = true,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultUserDto>()
            {
                Data = new ResultUserDto()
                {
                    UserId = user.Id,
                    PhoneNumber = user.PhoneNumber,
                },
                IsSuccess = true,
                Message = "ثبت نام کاربر با موفقیت انجام شد"
            };
        }
    }
}
