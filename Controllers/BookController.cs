using Library.Data;
using Library.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller, IBook
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                _ = _db.Add(book);
                var changes = _db.SaveChanges();
                return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            try
            {
                var books = _db.Books.ToList();
                return Json(books);
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }

        }
        [HttpGet]
        public ActionResult FindById(int id)
        {
            try
            {
                var book = _db.Books.Find(id);
                return Json(book);
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }

        }
        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });
            }
            else
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }
        }

        [HttpPut]
        public ActionResult UpdateBook(Book book)
        {
            try
            {
                _ = _db.Books.Update(book);
                _db.SaveChanges();
                return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }
        }

    }
}
