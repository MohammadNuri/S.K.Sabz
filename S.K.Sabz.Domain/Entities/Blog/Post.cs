using S.K.Sabz.Domain.Entities.Commons;
using S.K.Sabz.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Blog
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public bool IsSpecial { get; set; }


        //Many to One
        public virtual Category Category { get; set; } 
        public long CategoryId { get; set; } //Forigen Key
        public virtual User User { get; set; }
        public long UserId { get; set; }

        //Many to One
        public virtual Slider1 Slider1 { get; set; }
        public long Silder1Id { get; set; }

        //Many to One
        public virtual Slider2 Slider2 { get; set; }
        public long Slider2Id { get; set; }

        //One to Many
        public virtual ICollection<PostImages> PostImages { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }



    }
}
