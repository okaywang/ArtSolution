using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Initializers
{
    public class ArtDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<ArtDbContext>
    {
        protected override void Seed(ArtDbContext context)
        {
            var professionsString = "油画家 版画家 国画家 漫画家 水墨画家 当代艺术家 摄影家";
            var professions = professionsString.Split(' ');
            for (var i = 0; i < professions.Length; i++)
            {
                var prof = new Profession
                {
                    Id = i + 1,
                    Name = professions[i]
                };
                context.Set<Profession>().Add(prof);
            };

            var genresString = "风景 人物 抽像 动物 植物 山水 其它";
            var genres = genresString.Split(' ');
            for (var i = 0; i < genres.Length; i++)
            {
                var genre = new Genre
                {
                    Id = i + 1,
                    Name = genres[i]
                };
                context.Set<Genre>().Add(genre);
            };

            context.SaveChanges();

            var artist = new Artist()
            {
                Name = "zhangheng",
                Birthday = DateTime.Now.AddYears(-10),
                School = "Peiking University",
                Gender = Genders.Female,
                PrizeItems = "aaaa",
                Degree = Degree.博士,
                Professions = new Profession[] { context.Set<Profession>().First() },
                SkilledGenres = new Genre[] { context.Set<Genre>().First() }
            };
            context.Set<Artist>().Add(artist);


            var user = new User
            {
                Name = "liu zhiwei",
                LoginName = "lzw",
                Password = "123",
                Position = "PM",
                Contact = "13866666666"
            };

            context.Set<User>().Add(user);


            var typeName = "artworkType1";
            var artworkType = new ArtworkType()
            {
                Name = "artworkType1"
            };
            artworkType.ArtMaterials = new List<ArtMaterial>();
            artworkType.ArtMaterials.Add(new ArtMaterial
            {
                Name = typeName + "-material-1"
            });
            artworkType.ArtShapes = new List<ArtShape>();
            artworkType.ArtShapes.Add(new ArtShape
            {
                Name = typeName + "-shape-1"
            });
            artworkType.ArtShapes.Add(new ArtShape
            {
                Name = typeName + "-shape-2"
            });
            context.Set<ArtworkType>().Add(artworkType);


            context.SaveChanges();

            var at = context.Set<ArtworkType>().First();
            at.ArtMaterials.Add(new ArtMaterial
            {
                Name = "dddd"
            });
            context.SaveChanges();


            var artPlaces = new List<ArtPlace>() { new ArtPlace { Name = "卧室" }, new ArtPlace { Name = "客厅" }, new ArtPlace { Name = "餐厅" }, new ArtPlace { Name = "办公室" } };
            context.Set<ArtPlace>().AddRange(artPlaces);

            var artPeriods = new List<ArtPeriod>() { new ArtPeriod { Name = "50 n" }, new ArtPeriod { Name = "60 n" }, new ArtPeriod { Name = "70 n" } };
            context.Set<ArtPeriod>().AddRange(artPeriods);

            var auctionTypes = new List<AuctionType>() { new AuctionType { Name = "一口价 " }, new AuctionType { Name = "竞价拍-上升价格拍" }, new AuctionType { Name = "竞价拍-向下价格拍 " } };
            context.Set<AuctionType>().AddRange(auctionTypes);

            context.SaveChanges();

            var artwork = new Artwork();
            artwork.Name = "蒙娜丽莎的微笑";
            artwork.Artist = context.Set<Artist>().First();
            artwork.ArtMaterial = context.Set<ArtMaterial>().First();
            artwork.ArtPeriod = context.Set<ArtPeriod>().First();
            artwork.ArtworkType = context.Set<ArtworkType>().First();
            artwork.AuctionType = context.Set<AuctionType>().First();
            artwork.Genre = context.Set<Genre>().First();
            artwork.AuctionPrice = 998;
            artwork.CreationInspiration = "apple";
            artwork.Institution = "guowuyuan";
            artwork.SuitableArtPlaces = new List<ArtPlace> { context.Set<ArtPlace>().First() };
            artwork.Size = "80cm * 90cm";
            artwork.StartDateTime = DateTime.Now.AddDays(-3);
            artwork.EndDateTime = DateTime.Now.AddDays(3);
            context.Set<Artwork>().Add(artwork);

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
