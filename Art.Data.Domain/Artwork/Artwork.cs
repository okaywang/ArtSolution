using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Artwork : BaseEntity
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public string Institution { get; set; }
        public string Size { get; set; }

        public decimal Price { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public ArtworkType ArtworkType { get; set; }
        public ArtMaterial ArtMaterial { get; set; }
        public ArtShape ArtShape { get; set; }
        public ArtTechnique ArtTechnique { get; set; }
    }
}
