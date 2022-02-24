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
        // GET: Book
        public ActionResult Index()
        {
            return View();
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

    }
}
