using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;
using MyLibrary.DAL;
using PagedList;
using System.Web.UI;

namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        private DAL.Data _db;
        public BookController()
        {
            _db = new Data();

        }
        public BookController(Data db)
        {
            _db = db;

        }

     
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(_db.books.ToList());
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
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id=_db.books.Count + 1;
                _db.books.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Book book = _db.books.Single(r => r.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var book = _db.books.Find(x => x.Id.Equals(id));
            if (book == null)
            {

                return HttpNotFound();
            }
         
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = _db.books.Find(x => x.Id.Equals(id));
            if (book == null)
            {

                return HttpNotFound();
            }

            else
            {
                _db.books.Remove(book);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Search(string name = "")
        {

            var message = Server.HtmlEncode(name);
            return Content(message);
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.books
                   .Where(r => r.Title.StartsWith(term) || r.Author.StartsWith(term))
                   .Take(10)
                   .Select(r => new
                   {
                       label = r.Title
                   });

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Long", VaryByHeader = "X-Requested-With;Accept-Language", Location = OutputCacheLocation.Server)]
        public ActionResult SearchBooks(string searchTerm = null, int page = 1)
        {

            var model =
                _db.books
                   .Where(r => searchTerm == null || r.Title.StartsWith(searchTerm))
                   .Select(r => new Book
                   {
                       Id = r.Id,

                   }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Books", model);
            }

            return View(model);
        }

    }
}