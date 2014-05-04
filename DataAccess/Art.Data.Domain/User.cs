﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        [MaxLength(40)]
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Contact { get; set; }
    }
}