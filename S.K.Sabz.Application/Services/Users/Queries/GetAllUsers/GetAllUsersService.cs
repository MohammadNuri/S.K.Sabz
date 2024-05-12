using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries.GetAllUsers
{
	public class GetAllUsersService : IGetAllUsersService
	{
		private readonly IDataBaseContext _context;
        public GetAllUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultUsersDto Execute(RequestUserDto request)
		{
			var users = _context.Users
				.Include(p => p.UserInRoles)
				.ThenInclude(p => p.Role)
                .AsQueryable();

			if (!string.IsNullOrWhiteSpace(request.SearchKey))
			{
				users = users.Where(p => p.FirstName.Contains(request.SearchKey) && p.LastName.Contains(request.SearchKey));
			}
			int rowCount = 0;

			var userList = users.ToPaged(request.Page , 20 , out rowCount).Select(p => new UserDto
			{
				Id = p.Id,
				FirstName = p.FirstName,
				LastName = p.LastName,
				IsActive = p.IsActive,
				PhoneNumber = p.PhoneNumber,
				InsertTime = p.InsertTime,
				Roles = string.Join(", ", p.UserInRoles.Select(item => item.Role.Name)),
			}).ToList();


			return new ResultUsersDto
			{
				Rows = rowCount,
				Users = userList
			};
		}
	}
}
