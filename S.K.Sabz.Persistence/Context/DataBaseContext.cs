using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.AuthScheme.PoP;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Domain.Entities.Blog;
using S.K.Sabz.Domain.Entities.Users;
using S.K.Sabz.Persistence.Context.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions opetions) : base(opetions)
        {
        }
        public DbSet<User> Users { get; set; }
		public DbSet<UserInfo> UsersInfo { get; set; }
		public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImages> PostImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //--Seed Data
            //--Add Data For Roles
            AddData.SeedData(modelBuilder);

            //--Apply Index On Email
            //--Emails cant be Duplicate 
            ApplyIndex.HasIndex(modelBuilder);

            //--Not Showing Deleted Data
            //--!IsRemoved
            QueryFilter.ApplyQueryFilter(modelBuilder);
        }
	}
}
