using MyLibrary.DAL;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public class BrrowerController : Controller
    {

        private DAL.Data _db;

        public BrrowerController()
        {
            _db = new Data();
        }

        public ActionResult Index()
        {
            return View(_db.brrower.ToList());
        }

        //
        // GET: /Book/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Borrower brrower)
        {
            if (ModelState.IsValid)
            {
                brrower.Id = _db.brrower.Count + 1;
                _db.brrower.Add(brrower);
                return RedirectToAction("Index");
            }

            return View(brrower);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Borrower brrower = _db.brrower.Single(r => r.Id == id);
            if (brrower == null)
            {
                return HttpNotFound();
            }
            return View(brrower);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book brrower)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(brrower);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var brrower = _db.brrower.Find(x => x.Id.Equals(id));
            if (brrower == null)
            {

                return HttpNotFound();
            }

            return View(brrower);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var brrower = _db.brrower.Find(x => x.Id.Equals(id));
            if (brrower == null)
            {

                return HttpNotFound();
            }

            else
            {
                _db.brrower.Remove(brrower);
            }

            return RedirectToAction("Index");
        }

    }
}
