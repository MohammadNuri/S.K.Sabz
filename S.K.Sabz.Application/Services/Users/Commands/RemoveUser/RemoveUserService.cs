using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Common.Dto;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر پیدا نشد"
                };
            }

            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }

    }
}
