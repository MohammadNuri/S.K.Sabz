using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Users.Commands
{
    public class ResultUserDto
    {
        public long UserId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
