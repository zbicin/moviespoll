using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poll.Models;

namespace Poll.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Context;

        public HomeController() : base()
        {
            this.Context = new ApplicationDbContext();
        }
        public ActionResult Poll()
        {
            return View(new PollViewModel(Context.Movies.ToList()));
        }

        [HttpPost]
        public ActionResult Poll(PollViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Person()
                {
                    Description = model.PersonName
                };

                this.Context.Persons.Add(author);
                this.Context.SaveChanges();

                foreach (var singleVote in model.Votes)
                {
                    this.Context.Evaluations.Add(new Evaluation()
                    {
                        Grade = singleVote.Grade,
                        Movie = Context.Movies.SingleOrDefault(m => m.Id == singleVote.MovieId),
                        Person = author
                    });
                }
                this.Context.SaveChanges();
                return RedirectToAction("Thanks");
            }
            return View(model);
        }

        public ActionResult Init()
        {
            Context.Database.Delete();
            Context.Database.Initialize(true);
            return View("Poll");
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}