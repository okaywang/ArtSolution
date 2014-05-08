using Art.BussinessLogic;
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
        public int Value { get; set; }
        public string Text { get; set; }
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
            to.Value = from.Id;
            to.Text = from.Name;
            to.ArtMaterials = ArtMaterialModelTranslator.Instance.Translate(from.ArtMaterials);
            to.ArtShapes = ArtShapeModelTranslator.Instance.Translate(from.ArtShapes);
            to.ArtTechniques = ArtTechniqueModelTranslator.Instance.Translate(from.ArtTechniques);
            return to;
        }

        public override ArtworkType Translate(ArtworkTypeModel from)
        {
            var to = new ArtworkType();
            if (from.Value > 0)
            {
                to = ArtworkBussinessLogic.Instance.GetArtworkType(from.Value);
            }
            to.Name = from.Text;


            to.ArtMaterials = new List<ArtMaterial>();

            foreach (var item in from.ArtMaterials)
            {
                if (item.Value > 0)
                {
                    var artwork = ArtworkBussinessLogic.Instance.GetArtMaterial(item.Value);
                    artwork.Name = item.Text;
                    to.ArtMaterials.Add(artwork);
                }
                else
                {
                    to.ArtMaterials.Add(new ArtMaterial
                    {
                        Name = item.Text,
                    });
                }
            }


            to.ArtShapes = new List<ArtShape>();
            foreach (var item in from.ArtShapes)
            {
                if (item.Value > 0)
                {
                    var artshape = ArtworkBussinessLogic.Instance.GetArtShape(item.Value);
                    artshape.Name = item.Text;
                    to.ArtShapes.Add(artshape);
                }
                else
                {
                    to.ArtShapes.Add(new ArtShape
                    {
                        Name = item.Text,
                    });
                }
            }


            to.ArtTechniques = new List<ArtTechnique>();
            foreach (var item in from.ArtTechniques)
            {
                if (item.Value > 0)
                {
                    var technique = ArtworkBussinessLogic.Instance.GetArtTechnique(item.Value);
                    technique.Name = item.Text;
                    to.ArtTechniques.Add(ArtworkBussinessLogic.Instance.GetArtTechnique(item.Value));
                }
                else
                {
                    to.ArtTechniques.Add(new ArtTechnique
                    {
                        Name = item.Text,
                    });
                }
            }
            return to;
        }
    }
}