using Library.Data;
using Library.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller, IBook
    {
        private readonly IBookLogic _book;

        public BookController(IBookLogic book)
        {
            _book = book;
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                await _book.AddBook(book);
                return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });
            }
            catch
            {
                return BadRequest();
            }

            }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                var allBooks = await _book.GetAllBooks();
                return Json(allBooks);
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }

        }
        [HttpGet]
        public async Task<ActionResult> FindById(int id)
        {
            try
            {
                var RequestedBook = await _book.FindBookById(id);
                return Json(RequestedBook);
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var result = _book.RemoveBook(id);
                if (await result == true){
                    return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });
                }
                else
                {
                    return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
                }
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(Data.Book book)
        {
            try
            {
                await _book.UpdateBookDetails(book);
                return Json(new { IsProcessDone = true, ProcessMessage = "Success!" });
            }
            catch
            {
                return Json(new { IsProcessDone = false, ProcessMessage = "Failure :(" });
            }
            
        }

    }
}
