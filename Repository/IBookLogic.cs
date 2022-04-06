using Library.Data;

namespace Library.Repository
{
    public interface IBookLogic
    {
        Task AddBook(Book book);
        Task<Book> FindBookById(int id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<bool> RemoveBook(int id);
        Task UpdateBookDetails(Book book);
    }
}