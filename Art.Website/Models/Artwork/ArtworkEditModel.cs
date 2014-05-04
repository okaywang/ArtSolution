using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtworkEditModel
    {
        public ArtworkModel Artwork { get; set; }

        public IList<IdNameModel> SourceArtists { get; set; }

        public IList<IdNameModel> SourceArtPeriods { get; set; }

        public IList<IdNameModel> SourceArtPlaces { get; set; }

        public IList<IdNameModel> SourceGenres { get; set; }

        public IList<IdNameModel> SourceAuctionTypes { get; set; }

        public IList<ArtworkTypeModel> SourceArtworkTypes { get; set; }

        //public IList<IdNameModel> SourceArtMaterials { get; set; }
    }

}