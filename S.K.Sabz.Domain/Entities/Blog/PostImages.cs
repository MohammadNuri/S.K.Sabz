using S.K.Sabz.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Blog
{
    public class PostImages : BaseEntity
    {
        public string Src { get; set; } = string.Empty;


        //Many to One
        public virtual Post Post { get; set; }
        public long PostId { get; set; } // Forigen Key


    }
}
