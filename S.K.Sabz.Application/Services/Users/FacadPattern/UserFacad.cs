using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Users.Commands;
using S.K.Sabz.Application.Services.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.FacadPattern
{
    public class UserFacad : IUserFacad
    {

        //--Inject DataBase
        private readonly IDataBaseContext _context;
        public UserFacad(IDataBaseContext context)
        {
            _context = context;
        }


        //--Inject AddNewCategoryService
        private LoginUserService _loginUserService;
        public LoginUserService LoginUserService
        {
            get
            {
                return _loginUserService = _loginUserService ?? new LoginUserService(_context);
            }
        }

        private IGetUserById _getUserById;
        public IGetUserById GetUserById
        {
            get
            {
                return _getUserById = _getUserById ?? new GetUserById(_context);    
            }
        }

        private UpdateUserInfoService _updateUserInfoService;
        public UpdateUserInfoService UpdateUserInfoService
		{
            get
            {
                return _updateUserInfoService = _updateUserInfoService ?? new UpdateUserInfoService(_context);
            }
        }
    }
}
