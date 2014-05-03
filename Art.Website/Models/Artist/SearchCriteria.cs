﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models.Views.AristManage
{
    public class SearchCriteria
    {
        public SearchCriteria()
            : this(20)
        {

        }
        public SearchCriteria(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }
        public string NamePart { get; set; }
        public int? ProfessionId { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}