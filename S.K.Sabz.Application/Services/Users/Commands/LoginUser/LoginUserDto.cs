using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands.LoginUser
{
	public class LoginUserDto
    {
        public string PhoneNumber { get; set; } = string.Empty;
		public List<RolesInLoginUserDto> Roles { get; set; }
	}
}
