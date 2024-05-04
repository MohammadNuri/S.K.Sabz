using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Persistence.Context.EntityConfigurations
{
    public class QueryFilter
    {
        public static void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
			modelBuilder.Entity<UserInfo>().HasQueryFilter(p => !p.IsRemoved);
			modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
			modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<PostComment>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<PostImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider1>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider2>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
