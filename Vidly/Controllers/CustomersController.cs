using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context; // per utilizzare DB

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            //IEnumerable<Customer> lClienti = new List<Customer> {
            //    new Customer {Id =0, Name = "Enrico"},
            //    new Customer {Id =1, Name = "Cliente 2"},
            //    new Customer {Id =2, Name = "Cliente 3"}
            //};

            var lClienti = _context.Customers.Include(c => c.MembershipType).ToList();

            if (lClienti == null)
                return HttpNotFound();

            return View(lClienti);
        }

        public ActionResult Edit(int Id)
        {

            //var lClienti = new List<Customer>
            //{
            //    new Customer {Id =0, Name = "Enrico"},
            //    new Customer {Id =1, Name = "Cliente 2"},
            //    new Customer {Id =2, Name = "Cliente 3"}
            //};

            var cliente = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (cliente == null)
                return HttpNotFound();

            // var cliente = new Customer() { Id = lClienti[Id].Id, Name = lClienti[Id].Name};

            return View(cliente);
        }

    }
}