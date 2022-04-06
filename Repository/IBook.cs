using Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Repository
{
    public interface IBook
    {
        Task<ActionResult> Create(Book entity);
        Task<ActionResult> GetBooks();
        Task<ActionResult> FindById(int id);
        Task<ActionResult> DeleteBook(int id);
        Task<ActionResult> UpdateBook(Book book);
    }
}

