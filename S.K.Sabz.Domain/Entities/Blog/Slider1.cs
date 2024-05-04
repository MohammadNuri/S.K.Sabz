using S.K.Sabz.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace S.K.Sabz.Domain.Entities.Blog
{
    public class Slider1 : BaseEntity
    {
        public string Src { get; set; } = string.Empty;
        public string? Link { get; set; }
        public long ClickCount { get; set; }

    }
}
