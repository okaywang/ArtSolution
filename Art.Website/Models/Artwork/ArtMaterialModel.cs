using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtMaterialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ArtMaterialTranslator : TranslatorBase<ArtMaterial, ArtMaterialModel>
    {
        public static readonly ArtMaterialTranslator Instance = new ArtMaterialTranslator();

        public override ArtMaterialModel Translate(ArtMaterial from)
        {
            var to = new ArtMaterialModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override ArtMaterial Translate(ArtMaterialModel from)
        {
            var to = new ArtMaterial();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}