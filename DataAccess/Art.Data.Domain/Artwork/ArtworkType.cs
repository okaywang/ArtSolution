﻿using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Domain
{
    public class ArtworkType : BaseEntity, ISoftDelete, IIdNameEntry
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ArtMaterial> ArtMaterials { get; set; }

        public virtual ICollection<ArtShape> ArtShapes { get; set; }

        public virtual ICollection<ArtTechnique> ArtTechniques { get; set; }
    }
}
