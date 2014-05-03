using Art.Data.Database;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
using WebExpress.Core.Guards;

namespace Art.BussinessLogic
{
    public class ArtworkBussinessLogic
    {
        public static readonly ArtworkBussinessLogic Instance = new ArtworkBussinessLogic();

        private readonly IRepository<ArtworkType> _artworkTypeRepository;
        private readonly IRepository<Artwork> _artworkRepository;
        private readonly IRepository<ArtMaterial> _artMaterialRepository;
        private readonly IRepository<ArtShape> _artShapeRepository;
        private readonly IRepository<ArtTechnique> _artTechniqueRepository;
        private readonly IRepository<ArtPeriod> _artPeriodRepository;
        private readonly IRepository<ArtPlace> _artPlaceRepository;
        private readonly IRepository<AuctionType> _auctionTypeRepository;

        private ArtworkBussinessLogic()
        {
            _artworkTypeRepository = new EfRepository<ArtworkType>();
            _artworkRepository = new EfRepository<Artwork>();
            _artMaterialRepository = new EfRepository<ArtMaterial>();
            _artShapeRepository = new EfRepository<ArtShape>();
            _artTechniqueRepository = new EfRepository<ArtTechnique>();
            _artPeriodRepository = new EfRepository<ArtPeriod>();
            _artPlaceRepository = new EfRepository<ArtPlace>();
            _auctionTypeRepository = new EfRepository<AuctionType>();
        }

        public List<ArtworkType> GetArtworkTypes()
        {
            var types = _artworkTypeRepository.Table.ToList();
            return types;
        }

        public ArtworkType GetArtworkType(int id)
        {
            return _artworkTypeRepository.GetById(id);
        }

        public bool CanDeleteArtworkType(ArtworkType artworkType, out List<string> reasons)
        {
            reasons = new List<string>();
            if (artworkType.Name == "漫画")
            {
                reasons.Add("cartoon can not be deleted!");
                return false;
            }
            return true;
        }

        public bool DeleteArtworkType(ArtworkType artworkType)
        {
            _artworkTypeRepository.Delete(artworkType);
            return true;
        }

        public Artwork GetArtwork(int id)
        {
            var artwork = _artworkRepository.GetById(id);
            return artwork;
        }


        public ArtMaterial GetArtMaterial(int id)
        {
            return _artMaterialRepository.GetById(id);
        }

        public ArtShape GetArtShape(int id)
        {
            return _artShapeRepository.GetById(id);
        }

        public ArtTechnique GetArtTechnique(int id)
        {
            return _artTechniqueRepository.GetById(id);
        }

        public ArtPeriod GetPeriod(int id)
        {
            return _artPeriodRepository.GetById(id);
        }

        public ICollection<ArtPeriod> GetPeriods()
        {
            return _artPeriodRepository.Table.ToList();
        }

        public ICollection<ArtPlace> GetPlaces()
        {
            return _artPlaceRepository.Table.ToList();
        }

        public AuctionType GetAuctionType(int id)
        {
            return _auctionTypeRepository.GetById(id);
        }

        public ICollection<AuctionType> GetAuctionTypes()
        {
            return _auctionTypeRepository.Table.ToList();
        }

        public ICollection<ArtPlace> GetArtPlaces(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }

            var query = from p in _artPlaceRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            return query.ToList();
        }

        
    }
}
