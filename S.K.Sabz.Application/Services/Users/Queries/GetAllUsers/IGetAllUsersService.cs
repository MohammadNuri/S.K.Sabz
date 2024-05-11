﻿using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries.GetAllUsers
{
	public interface IGetAllUsersService
	{
		ResultUsersDto Execute(RequestUserDto request);
	}
}