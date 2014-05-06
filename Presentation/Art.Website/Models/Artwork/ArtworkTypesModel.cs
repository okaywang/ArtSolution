using Art.Data.Domain;
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
        public IList<ArtworkTypeModel> ArtworkTypes { get; set; }
    }

    public class ArtworkTypeModel
    {
        public ArtworkTypeModel()
        {
            ArtMaterials = new List<ArtMaterialModel>();
            ArtShapes = new List<ArtShapeModel>();
            ArtTechniques = new List<ArtTechniqueModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ArtMaterialModel> ArtMaterials { get; set; }
        public IList<ArtShapeModel> ArtShapes { get; set; }
        public IList<ArtTechniqueModel> ArtTechniques { get; set; }
    }



    public class ArtworkTypeModelTranslator : TranslatorBase<ArtworkType, ArtworkTypeModel>
    {
        public static readonly ArtworkTypeModelTranslator Instance = new ArtworkTypeModelTranslator();

        public override ArtworkTypeModel Translate(ArtworkType from)
        {
            var to = new ArtworkTypeModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ArtMaterials = ArtMaterialModelTranslator.Instance.Translate(from.ArtMaterials);
            to.ArtShapes = ArtShapeModelTranslator.Instance.Translate(from.ArtShapes);
            to.ArtTechniques = ArtTechniqueModelTranslator.Instance.Translate(from.ArtTechniques);  
            return to;
        }

        public override ArtworkType Translate(ArtworkTypeModel from)
        {
            throw new NotImplementedException();
        }
    }
}