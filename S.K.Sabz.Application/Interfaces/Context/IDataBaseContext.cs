using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
		DbSet<UserInfo> UsersInfo { get; set; }
		DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
		DbSet<Category> Categories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostComment> PostComments { get; set; }
        DbSet<PostImages> PostImages { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
