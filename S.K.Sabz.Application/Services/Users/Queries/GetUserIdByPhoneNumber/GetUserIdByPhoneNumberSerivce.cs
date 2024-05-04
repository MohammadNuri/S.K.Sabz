using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Services.Users.Commands.LoginUser;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries.GetUserIdByPhoneNumber
{
    public class GetUserIdByPhoneNumberSerivce : IGetUserIdByPhoneNumberSerivce
	{
		private readonly IDataBaseContext _context;
        public GetUserIdByPhoneNumberSerivce(IDataBaseContext context)
        {
            _context = context;
        }

		public async Task<long> Execute(LoginUserDto phoneNumber)
		{
			// Query the database to find the user with the provided phone number
			var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber.PhoneNumber);

			// If user is found, return the userId, otherwise return null
			return user.Id;
		}
	}
}
