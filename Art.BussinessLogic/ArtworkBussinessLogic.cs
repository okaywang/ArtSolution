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

        private readonly IRepository<ArtworkType> _artworkRepository;

        private ArtworkBussinessLogic()
        {
            _artworkRepository = new EfRepository<ArtworkType>();
        }

        public List<ArtworkType> GetArtworkTypes()
        {
            var types = _artworkRepository.Table.ToList();
            return types;
        }

        public ArtworkType GetArtworkType(int id)
        {
            return _artworkRepository.GetById(id);
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
            _artworkRepository.Delete(artworkType);
            return true;
        }



    }
}
