using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Poll.Models
{
    public class Person
    {
        [Column("ID")]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}