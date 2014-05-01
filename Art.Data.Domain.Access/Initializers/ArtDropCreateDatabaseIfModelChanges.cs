﻿using System;
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
            //artworkType.ArtMaterials.Add(new ArtMaterial
            //{
            //    Name = typeName + "-material-2"
            //});
            context.Set<ArtworkType>().Add(artworkType);

            try
            {
                context.SaveChanges();

                var at = context.Set<ArtworkType>().First();
                at.ArtMaterials.Add(new ArtMaterial
                {
                    Name = "dddd"
                });
                context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
            
            }

            


            //base.Seed(context);
        }
    }
}
