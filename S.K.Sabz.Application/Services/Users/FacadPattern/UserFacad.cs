using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Users.Commands.LoginUser;
using S.K.Sabz.Application.Services.Users.Commands.RemoveUser;
using S.K.Sabz.Application.Services.Users.Commands.UpdateUserInfo;
using S.K.Sabz.Application.Services.Users.Commands.UserStatusChange;
using S.K.Sabz.Application.Services.Users.Queries.GetAllUsers;
using S.K.Sabz.Application.Services.Users.Queries.GetUserById;
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
		private IGetAllUsersService _getAllUsers;
		public IGetAllUsersService GetAllUsersService
		{
			get
			{
				return _getAllUsers = _getAllUsers ?? new GetAllUsersService(_context);
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
        private RemoveUserService _removeUserService;
        public RemoveUserService RemoveUserService
        {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            }
        }
		private UserStatusChangeService _userStatusChangeService;
		public UserStatusChangeService UserStatusChangeService
		{
			get
			{
				return _userStatusChangeService = _userStatusChangeService ?? new UserStatusChangeService(_context);
			}
		}
		

	}
}
