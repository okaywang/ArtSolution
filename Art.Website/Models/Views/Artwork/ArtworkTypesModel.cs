using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtworkTypesModel
    {
        public ArtworkTypesModel()
        {
            ArtworkTypes = new List<ArtworkTypeModel>();
        }
        public List<ArtworkTypeModel> ArtworkTypes { get; set; }
    }

    public class ArtworkTypeModel
    {
        public ArtworkTypeModel()
        {
            ArtMaterials = new List<ArtMaterialModel>();
            ArtShapes = new List<ArtShapeModel>();
            ArtTechniques = new List<ArtTechniqueModel>();
        }
        public string Name { get; set; }
        public List<ArtMaterialModel> ArtMaterials { get; set; }
        public List<ArtShapeModel> ArtShapes { get; set; }
        public List<ArtTechniqueModel> ArtTechniques { get; set; }
    }
}