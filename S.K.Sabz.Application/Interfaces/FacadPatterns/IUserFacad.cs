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

namespace S.K.Sabz.Application.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        LoginUserService LoginUserService { get; }
        IGetUserById GetUserById {  get; }
        UpdateUserInfoService UpdateUserInfoService { get; }
		IGetAllUsersService GetAllUsersService { get; }
        RemoveUserService RemoveUserService { get; }
		UserStatusChangeService UserStatusChangeService { get; }

	}
}
