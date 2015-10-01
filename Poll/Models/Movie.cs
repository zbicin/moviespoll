using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Poll.Models
{
    public class Movie
    {
        [Column("ID")]
        public int Id { get; set; }
        public int TMBID { get; set; }
        public string Title { get; set; }
    }
}