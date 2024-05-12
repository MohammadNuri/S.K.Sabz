using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.ChangeRole
{
	public class ChangeRoleService : IChangeRoleService
	{
		private readonly IDataBaseContext _context;
        public ChangeRoleService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto MakeAdmin(long userId)
        {
            var user = _context.Users
                .Include(c => c.UserInRoles)
                .ThenInclude(c => c.Role)
                .FirstOrDefault(c => c.Id == userId);
            
            if(user == null)
            {
                return new ResultDto()
				{
					IsSuccess = false,
					Message = "کاربر پیدا نشد"
				};
			}

			foreach (var userInRole in user.UserInRoles)
			{
				if (userInRole.RoleId == 3)
				{
					userInRole.RoleId = 1;
					userInRole.UpdateTime = DateTime.Now;
				}
				else
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "کاربر انتخابی ادمین می باشد!"
					};
				}
			}

			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "نقش کاربر به ادمین تغییر یافت!"
			};
        }

		public ResultDto MakeCustomer(long userId)
		{
			var user = _context.Users
				.Include(c => c.UserInRoles)
				.ThenInclude(c => c.Role)
				.FirstOrDefault(c => c.Id == userId);

			if (user == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "کاربر پیدا نشد"
				};
			}

			foreach (var userInRole in user.UserInRoles)
			{
				if (userInRole.RoleId == 1)
				{
					userInRole.RoleId = 3;
					userInRole.UpdateTime = DateTime.Now;
				}
				else
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "کاربر انتخابی کاربر معمولی می باشد!"
					};
				}
			}

			_context.SaveChanges();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "نقش کاربر به کاربر معمولی تغییر یافت!"
			};
		}
	}
}
