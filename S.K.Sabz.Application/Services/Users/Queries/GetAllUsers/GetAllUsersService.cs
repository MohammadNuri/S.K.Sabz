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

        public ResultUsersDto Execute(string? searchKey, int page , int pageSize)
		{
			int totalRow = 0;
			var users = _context.Users
				.Include(p => p.UserInRoles)
				.ThenInclude(p => p.Role)
                .AsQueryable();

			if (!string.IsNullOrWhiteSpace(searchKey))
			{
				var searchKeys = searchKey.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				users = users.Where(p => searchKeys.Any(key =>
					p.FirstName.Contains(key) ||
					p.LastName.Contains(key) ||
					p.PhoneNumber.Contains(key)
				));
			}

			var userList = users
				.ToPaged(page, pageSize, out totalRow)
				.Select(p => new UserDto
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
				TotalRow = totalRow,
				Users = userList,
			};
		}
	}
}
