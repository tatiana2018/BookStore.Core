using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public  interface IBookServices
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(string id);
        Task CreateBook(Book newBook);
        Task DeleteBook(string id);
        Task UpdateBook(string id, Book updatedBook);

    }
}
