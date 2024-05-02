using S.K.Sabz.Application.Services.Users.Commands;
using S.K.Sabz.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries.GetUserIdByPhoneNumber
{
	public interface IGetUserIdByPhoneNumberSerivce
	{
		Task<long> Execute(LoginUserDto phoneNumber);
	}
}
