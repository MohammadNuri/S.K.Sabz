using S.K.Sabz.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Blog
{
	public class Category : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string? CategoryPicUrl { get; set; } = string.Empty;
		public virtual Category ParentCategory { get; set; }
		public long? ParentCategoryId { get; set; }

		//for showing SubCategory of Categories
		public virtual ICollection<Category> SubCategories { get; set; }
	}
}
