﻿using S.K.Sabz.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Users
{
	public class User : BaseEntity
    {
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public long PhoneNumber { get; set; }
        public bool IsActive { get; set; }
		public ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
		public UserInfo UserInfo { get; set; } // Navigation property for additional user information

	}
}
