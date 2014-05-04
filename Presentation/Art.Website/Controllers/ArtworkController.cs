﻿using Art.BussinessLogic;
using Art.Data.Domain;
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

            //model.ArtworkTypes.Add(new ArtworkTypeModel
            //{
            //    Name = "油画",
            //    ArtMaterials = new List<ArtMaterialModel> { new ArtMaterialModel { Id = 1, Name = "aa" }, new ArtMaterialModel { Id = 1, Name = "b" } },
            //    ArtShapes = new List<ArtShapeModel> { new ArtShapeModel { Id = 1, Name = "bb" } },
            //    ArtTechniques = new List<ArtTechniqueModel> { new ArtTechniqueModel { Id = 1, Name = "bb" } }
            //});
            //model.ArtworkTypes.Add(new ArtworkTypeModel
            //{
            //    Name = "版画",
            //    ArtMaterials = new List<ArtMaterialModel> { new ArtMaterialModel { Id = 1, Name = "aa" }, new ArtMaterialModel { Id = 1, Name = "b" } },
            //    ArtShapes = new List<ArtShapeModel> { new ArtShapeModel { Id = 1, Name = "bb" } },
            //    ArtTechniques = new List<ArtTechniqueModel> { new ArtTechniqueModel { Id = 1, Name = "bb" } }
            //});
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

        public ActionResult Add()
        {
            var artwork = new ArtworkModel();
            var model = GetArtworkEditModel(artwork);
            return View("Edit", model);
        }

        [HttpPost]
        public JsonResult Add(ArtworkModel model)
        {
            var artwork = ArtworkModelTranslator.Instance.Translate(model);

            ArtworkBussinessLogic.Instance.Add(artwork);

            var result = new ResultModel(true, "add successfully!");
            return Json(result);
        }

        [HttpPost]
        public JsonResult Update(ArtworkModel model)
        {
            var artwork = ArtworkModelTranslator.Instance.Translate(model);

            ArtworkBussinessLogic.Instance.Update(artwork);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            var artworkModel = ArtworkModelTranslator.Instance.Translate(artwork);
            var model = GetArtworkEditModel(artworkModel);
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = new ArtworkManageModel();

            var defaultCriteria = new ArtworkSearchCriteria(10);
            model.PagedArtworks = GetPagedArtistModel(defaultCriteria);
             
            return View(model);
        }

        private PagedArtworkModel GetPagedArtistModel(ArtworkSearchCriteria criteria)
        {
            var artworks = new List<ArtworkSimpleModel>();
            var pagedArtworks = ArtworkBussinessLogic.Instance.SearchArtworks(criteria.NamePart, criteria.ArtworkTypeId, criteria.ArtMaterialId, criteria.ArtistId, criteria.PagingRequest);
            foreach (var item in pagedArtworks)
            {
                var artwork = ArtworkSimpleModelTranslator.Instance.Translate(item);
                //artist.CanUnPublish = Art.BussinessLogic.ArtistBussinessLogic.Instance.CanUnpublish(item);
                artworks.Add(artwork);
            }

            var model = new PagedArtworkModel(artworks, pagedArtworks.PagingResult);
            return model;
        }

        private ArtworkEditModel GetArtworkEditModel(ArtworkModel artworkModel)
        {
            var model = new ArtworkEditModel();
            model.Artwork = artworkModel;

            var artists = ArtistBussinessLogic.Instance.GetArtists();
            model.SourceArtists = IdNameModelTranslator<Artist>.Instance.Translate(artists);

            var artworkTypes = ArtworkBussinessLogic.Instance.GetArtworkTypes();
            model.SourceArtworkTypes = ArtworkTypeModelTranslator.Instance.Translate(artworkTypes);

            var genres = ArtistBussinessLogic.Instance.GetGenres();
            model.SourceGenres = IdNameModelTranslator<Genre>.Instance.Translate(genres);

            var periods = ArtworkBussinessLogic.Instance.GetPeriods();
            model.SourceArtPeriods = IdNameModelTranslator<ArtPeriod>.Instance.Translate(periods);

            var places = ArtworkBussinessLogic.Instance.GetPlaces();
            model.SourceArtPlaces = IdNameModelTranslator<ArtPlace>.Instance.Translate(places);

            var auctionTypes = ArtworkBussinessLogic.Instance.GetAuctionTypes();
            model.SourceAuctionTypes = IdNameModelTranslator<AuctionType>.Instance.Translate(auctionTypes);
             
            return model;
        }

    }
}