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
        public List<ArtworkTypeModel> ArtworkTypes { get; set; }
    }

    public class ArtworkTypeModel
    {
        public ArtworkTypeModel()
        {
            ArtMaterials = new List<IdNameModel>();
            ArtShapes = new List<IdNameModel>();
            ArtTechniques = new List<IdNameModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<IdNameModel> ArtMaterials { get; set; }
        public IList<IdNameModel> ArtShapes { get; set; }
        public IList<IdNameModel> ArtTechniques { get; set; }
    }



    public class ArtworkTypeModelTranslator : TranslatorBase<ArtworkType, ArtworkTypeModel>
    {
        public static readonly ArtworkTypeModelTranslator Instance = new ArtworkTypeModelTranslator();

        public override ArtworkTypeModel Translate(ArtworkType from)
        {
            var to = new ArtworkTypeModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ArtMaterials = IdNameModelTranslator<ArtMaterial>.Instance.Translate(from.ArtMaterials);

            to.ArtShapes = IdNameModelTranslator<ArtShape>.Instance.Translate(from.ArtShapes);
            to.ArtTechniques = IdNameModelTranslator<ArtTechnique>.Instance.Translate(from.ArtTechniques);  
            return to;
        }

        public override ArtworkType Translate(ArtworkTypeModel from)
        {
            throw new NotImplementedException();
        }
    }
}