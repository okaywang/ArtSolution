using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtMaterialModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool IsUsed { get; set; }
    }

    public class ArtMaterialModelTranslator : TranslatorBase<ArtMaterial, ArtMaterialModel>
    {
        public static readonly ArtMaterialModelTranslator Instance = new ArtMaterialModelTranslator();

        public override ArtMaterialModel Translate(ArtMaterial from)
        {
            var to = new ArtMaterialModel();
            to.Value = from.Id;
            to.Text = from.Name;
            to.IsUsed = from.Artworks.Any();
            return to;
        }

        public override ArtMaterial Translate(ArtMaterialModel from)
        {
            var to = new ArtMaterial();
            to.Id = from.Value;
            to.Name = from.Text;
            return to;
        }
    }
}