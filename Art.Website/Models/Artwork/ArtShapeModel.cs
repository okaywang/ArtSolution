using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtShapeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ArtShapeTranslator : TranslatorBase<ArtShape, ArtShapeModel>
    {
        public static readonly ArtShapeTranslator Instance = new ArtShapeTranslator();

        public override ArtShapeModel Translate(ArtShape from)
        {
            var to = new ArtShapeModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override ArtShape Translate(ArtShapeModel from)
        {
            var to = new ArtShape();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}