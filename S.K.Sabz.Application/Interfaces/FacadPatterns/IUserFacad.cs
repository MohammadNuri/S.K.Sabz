using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Users.Commands;
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
	}
}
