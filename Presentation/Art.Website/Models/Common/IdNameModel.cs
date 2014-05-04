using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{ 
    public class IdNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class IdNameModelTranslator<TDomain> : TranslatorBase<TDomain, IdNameModel> where TDomain : IIdNameEntity, new()
    {
        public static readonly IdNameModelTranslator<TDomain> Instance = new IdNameModelTranslator<TDomain>();

        public override IdNameModel Translate(TDomain from)
        {
            var to = new IdNameModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override TDomain Translate(IdNameModel from)
        {
            var to = new TDomain();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}