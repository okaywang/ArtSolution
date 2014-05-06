using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtPlace : BaseEntity, IIdNameEntity, ISoftDelete
    {
        public string Name { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}
