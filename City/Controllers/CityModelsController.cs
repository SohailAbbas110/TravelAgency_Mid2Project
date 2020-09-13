using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using City.Models;

namespace City.Controllers
{
    public class CityModelsController : Controller
    {
        private CityDBContext db = new CityDBContext();

        // GET: CityModels
        public ActionResult Index(string searchString)
        {
            var cities = from c in db.cities
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(s => s.CityName.Contains(searchString));
            }

            return View(cities);
        }


        // GET: CityModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = db.cities.Find(id);
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // GET: CityModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityName,VisitDate,Country,Fare")] CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                db.cities.Add(cityModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityModel);
        }

        // GET: CityModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = db.cities.Find(id);
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: CityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityName,VisitDate,Country,Fare")] CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }

        // GET: CityModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = db.cities.Find(id);
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: CityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityModel cityModel = db.cities.Find(id);
            db.cities.Remove(cityModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
