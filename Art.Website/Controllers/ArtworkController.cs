using Art.BussinessLogic;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Website.Controllers
{
    public class ArtworkController : Controller
    {
        public ActionResult Types()
        {
            var model = new ArtworkTypesModel();
            
            model.ArtworkTypes.Add(new ArtworkTypeModel
            {
                Name="油画",
                ArtMaterials = new List<ArtMaterialModel> { new ArtMaterialModel { Id = 1, Name = "aa" }, new ArtMaterialModel { Id = 1, Name = "b" } },
                ArtShapes = new List<ArtShapeModel> { new ArtShapeModel { Id = 1, Name = "bb" } },
                ArtTechniques = new List<ArtTechniqueModel> { new ArtTechniqueModel { Id = 1, Name = "bb" } }
            });
            model.ArtworkTypes.Add(new ArtworkTypeModel
            {
                Name = "版画",
                ArtMaterials = new List<ArtMaterialModel> { new ArtMaterialModel { Id = 1, Name = "aa" }, new ArtMaterialModel { Id = 1, Name = "b" } },
                ArtShapes = new List<ArtShapeModel> { new ArtShapeModel { Id = 1, Name = "bb" } },
                ArtTechniques = new List<ArtTechniqueModel> { new ArtTechniqueModel { Id = 1, Name = "bb" } }
            });
            return View(model);
        }

        public JsonResult DeleteArtworkType(int id)
        {
            var artworkType = ArtworkBussinessLogic.Instance.GetArtworkType(id); 
            List<string> reasons;
            var model = new ResultModel(true, string.Empty);
            if (ArtworkBussinessLogic.Instance.CanDeleteArtworkType(artworkType, out reasons))
            {
                ArtworkBussinessLogic.Instance.DeleteArtworkType(artworkType);
            }
            else
            {
                model = new ResultModel(false, string.Join(",", reasons));
            }
            return Json(model);
        }

        public JsonResult UpdateArtworkType(ArtworkTypeModel model)
        {
            return null;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
