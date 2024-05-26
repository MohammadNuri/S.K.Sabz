using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Persistence.Context.EntityConfigurations
{
	public class ConfigureRelationship
	{
		public static void PostCommentConfig(ModelBuilder modelBuilder)
		{
			// Configure PostComment relationship with Post
			modelBuilder.Entity<PostComment>()
				.HasOne(pc => pc.Post)
				.WithMany(p => p.PostComments)
				.HasForeignKey(pc => pc.PostId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure PostComment relationship with User
			modelBuilder.Entity<PostComment>()
				.HasOne(pc => pc.User)
				.WithMany(u => u.PostComments)
				.HasForeignKey(pc => pc.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
