using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtTechniqueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ArtTechniqueTranslator : TranslatorBase<ArtTechnique, ArtTechniqueModel>
    {
        public static readonly ArtTechniqueTranslator Instance = new ArtTechniqueTranslator();

        public override ArtTechniqueModel Translate(ArtTechnique from)
        {
            var to = new ArtTechniqueModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override ArtTechnique Translate(ArtTechniqueModel from)
        {
            var to = new ArtTechnique();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}