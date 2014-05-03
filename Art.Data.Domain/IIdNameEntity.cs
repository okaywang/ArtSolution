using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public interface IIdNameEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
