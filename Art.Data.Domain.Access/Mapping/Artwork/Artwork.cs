﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ArtworkMap : EntityTypeConfiguration<Artwork>
    {
        public ArtworkMap()
        {
            this.HasRequired(i => i.Artist);
            this.HasRequired(i => i.ArtworkType);
            this.HasRequired(i => i.ArtMaterial);
        }
    }
}
