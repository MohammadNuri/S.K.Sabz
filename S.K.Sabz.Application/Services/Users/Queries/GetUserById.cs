using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Queries
{
    public class GetUserById : IGetUserById
    {
        private readonly IDataBaseContext _context;
        public GetUserById(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
