using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
