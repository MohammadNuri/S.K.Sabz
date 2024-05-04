using S.K.Sabz.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Domain.Entities.Blog
{
    public class Slider2 : BaseEntity
    {
        public string Src { get; set; } = string.Empty;
        public string? Link { get; set; }
        public long ClickCount { get; set; }

    }
}
