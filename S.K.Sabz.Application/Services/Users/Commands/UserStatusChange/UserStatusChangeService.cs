﻿using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.UserStatusChange
{
	public class UserStatusChangeService : IUserStatusChangeService
	{
		private readonly IDataBaseContext _context;
        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);
			if (user == null)
			{
				return new ResultDto
				{
					IsSuccess = false,
					Message = "کاربر یافت نشد"
				};
			}

			user.IsActive = !user.IsActive;
			_context.SaveChanges();
			string userState = user.IsActive == true ? "فعال" : "غیر فعال";
			return new ResultDto()
			{
				IsSuccess = true,
				Message = $"کاربر با موفقیت {userState} شد!",
			};
		}
	}
}
