using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Text;

namespace Poll.Models
{
    public class PollViewModel
    {
        [Required]
        public string PersonName { get; set; }
        public List<Vote> Votes { get; set; }

        public PollViewModel()
        {
            this.Votes = new List<Vote>();
        }

        public PollViewModel(List<Movie> movies) : this()
        {
            foreach (var singleMovie in movies)
            {
                this.Votes.Add(new Vote()
                {
                    MovieId = singleMovie.Id,
                    MovieTitle = singleMovie.Title,
                    MovieTMBID = singleMovie.TMBID
                });
            }
        }

        public class Vote
        {
            public int MovieId { get; set; }
            public int? Grade { get; set; }
            public string MovieTitle { get; set; }
            public int MovieTMBID { get; set; }
        }

    }
}
