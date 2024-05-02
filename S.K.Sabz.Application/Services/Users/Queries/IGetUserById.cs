using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries
{
	public interface IGetUserById
	{
		Task<User> GetUserByIdAsync(long userId);
	}
}
