using Microsoft.Owin.Security.Provider;
using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        // GET : Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                // _db is a snapshot of the database
                _db.Restaurants.Add(restaurant);
                // Save changes to the live database form the snapshot _db
                _db.SaveChanges();
                // redirect to action Index
                return RedirectToAction("Index");
            }
            // if the ModelState isn't valid, return the invalid model to us to display in the View
            return View(restaurant);
        }
    }
}