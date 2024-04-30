using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Persistence.Context.EntityConfigurations
{
    public class ApplyIndex
    {
        public static void HasIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
