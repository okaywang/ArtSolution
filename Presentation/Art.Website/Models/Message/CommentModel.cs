using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models.Comment
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Artwork { get; set; }
        public CommentState State { get; set; }
    }
}