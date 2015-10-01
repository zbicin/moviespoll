using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Poll.Models
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            string csvContents = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/movies.csv"));
            string[] rows = csvContents.Split('\r');

            foreach (var singleRow in rows)
            {
                string[] splittedSingleRow = singleRow.Split(';');
                if (splittedSingleRow.Length > 2)
                {
                    var singleMovie = new Movie()
                    {
                        Id = Int32.Parse(splittedSingleRow[0]),
                        Title = splittedSingleRow[2],
                        TMBID = Int32.Parse(splittedSingleRow[1])
                    };

                    context.Movies.Add(singleMovie);
                }
            }
            context.SaveChanges();
        }
    }
}