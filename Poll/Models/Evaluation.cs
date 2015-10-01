using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Poll.Models
{
    public class Evaluation
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("PersonID")]
        public virtual Person Person
        {
            get;
            set;
        }

        [Column("MovieID")]
        public virtual Movie Movie { get; set; }
        [Column("Evaluation")]
        public int Grade { get; set; }
    }
}