using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Common.Roles;
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


		public async Task<ResultDto<ResultUserDto>> LoginExecuteAsync(LoginUserDto request)
		{
			var user = await _context.Users
				.Include(p => p.UserInRoles)
				.ThenInclude(p => p.Role)
				.Where(p => p.PhoneNumber.Equals(request.PhoneNumber) && p.IsActive == true)
				.FirstOrDefaultAsync();

			if (user != null)
			{
				var roles = string.Join(", ", user.UserInRoles.Select(item => item.Role.Name));

				return new ResultDto<ResultUserDto>()
				{
					Data = new ResultUserDto()
					{
						UserId = user.Id,
						PhoneNumber = user.PhoneNumber,
						Roles = roles,
					},
					IsSuccess = true,
					Message = "ورود به سایت با موفقیت انجام شد",
				};
			}
			else
			{
				return await SignUpExecuteAsync(request);
			}
		}

		public async Task<ResultDto<ResultUserDto>> SignUpExecuteAsync(LoginUserDto request)
		{
			User user = new User()
			{
				PhoneNumber = request.PhoneNumber,
				IsActive = true,
			};

			List<UserInRole> userInRoles = new List<UserInRole>();
			foreach (var item in request.Roles)
			{
				var roles = _context.Roles.Find(item.Id);
				if (roles != null)
					userInRoles.Add(new UserInRole
					{
						Role = roles,
						RoleId = roles.Id,
						User = user,
						UserId = user.Id
					});
			}
			user.UserInRoles = userInRoles;


			_context.Users.Add(user);
			await _context.SaveChangesAsync();


			return new ResultDto<ResultUserDto>()
			{
				Data = new ResultUserDto()
				{
					UserId = user.Id,
					PhoneNumber = user.PhoneNumber,
					Roles = string.Join(", ", user.UserInRoles.Select(item => item.Role.Name)),
				},
				IsSuccess = true,
				Message = "ثبت نام کاربر با موفقیت انجام شد"
			};
		}
	}
}
