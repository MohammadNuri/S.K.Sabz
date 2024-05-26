using S.K.Sabz.Domain.Entities.Commons;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Blog
{
    public class PostComment : BaseEntity
    {
        public string Text { get; set; } = string.Empty;

        // Foreign key to the parent comment, null if this is not a reply
        public long? ParentCommentId { get; set; }
        public virtual PostComment ParentComment { get; set; }

        // Navigation property for replies
        public virtual ICollection<PostComment> Replies { get; set; } = new List<PostComment>();

        //Many to One
        public virtual Post Post { get; set; }
        public long PostId { get; set; }
		public virtual User User { get; set; }
		public long UserId { get; set; }
	}

}
