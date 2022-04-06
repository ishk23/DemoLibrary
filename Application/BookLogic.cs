using Library.Data;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Library.Application
{
    public class BookLogic : IBookLogic
    {
        private readonly ApplicationDbContext _db;
        public BookLogic(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddBook(Data.Book book)
        {
            _ = _db.Add(book);
            _db.SaveChanges();
        }


        public async Task<IEnumerable<Data.Book>> GetAllBooks()
        {
            var books = _db.Books.ToList();
            return books;
        }

        public async Task<Data.Book> FindBookById(int id)
        {
            var book = _db.Books.Find(id);
            return book;
        }

        public async Task<bool> RemoveBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task UpdateBookDetails(Data.Book book)
        {

            _ = _db.Books.Update(book);
            _db.SaveChanges();

        }

    }
}
