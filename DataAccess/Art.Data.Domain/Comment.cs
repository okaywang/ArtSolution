using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; }
        public CommentState State { get; set; }

        public Customer Customer { get; set; }
        public Artwork Artwork { get; set; }

        public DateTime FADateTime { get; set; }

        public string MyProperty { get; set; }
    }

    public class Reply:BaseEntity
    {
        public string Content { get; set; }
        public Comment Comment { get; set; }
        public AdminUser User { get; set; }

        public DateTime FADateTime { get; set; }
    }
}
