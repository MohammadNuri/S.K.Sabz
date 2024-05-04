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


        //Many to One
        public virtual Post Post { get; set; }
        public long PostId { get; set; }
    }

}
