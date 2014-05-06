using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtPeriod : BaseEntity, IIdNameEntity, ISoftDelete
    {
        public string Name { get; set; }
    }
}
