using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var oCinema = new Movie() { Name = "Coco" };

            var lClienti = new List<Customer>
            {
                new Customer {Name = "Cliente 1"},
                new Customer {Name = "Cliente 2"},
                new Customer {Name = "Cliente 3"}
            };

            var oViewModel = new RandomMovieViewModel()
                { Movie = oCinema,
                  Customers = lClienti
                }; 
           
            return View(oViewModel);
        }

        public ActionResult Edit(int movieId)
        {

            return Content("id= " + movieId);

        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (sortBy.IsNullOrWhiteSpace())
                sortBy = "name";

            return Content("pageIndex=" + pageIndex + " sortBy=" + sortBy);
        }

        [Route("movies/released/{year}/{month:regex(\\{d4}):range(1:12)}")]
        public ActionResult ReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);

        }

    }
}