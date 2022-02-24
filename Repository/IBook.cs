using Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Repository
{
    public interface IBook
    {
        ActionResult Create(Book entity);
    }
}
