﻿using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtShapeModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool IsUsed { get; set; }
    }

    public class ArtShapeModelTranslator : TranslatorBase<ArtShape, ArtShapeModel>
    {
        public static readonly ArtShapeModelTranslator Instance = new ArtShapeModelTranslator();

        public override ArtShapeModel Translate(ArtShape from)
        {
            var to = new ArtShapeModel();
            to.Value = from.Id;
            to.Text = from.Name;
            to.IsUsed = from.Artworks.Any();
            return to;
        }

        public override ArtShape Translate(ArtShapeModel from)
        {
            var to = new ArtShape();
            to.Id = from.Value;
            to.Name = from.Text;
            return to;
        }
    }
}