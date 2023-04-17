using MongoDB.Driver;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
       private readonly IMongoCollection<Book> _book;   
       public BookServices(IDbClient dbClient) {

            _book = dbClient.GetBooksCollection();
        }

       public async Task<List<Book>> GetAllBooks() =>
            await _book.Find(_ => true).ToListAsync();

        public async Task<Book?> GetBookById(string id) =>
            await _book.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateBook(Book newBook) =>
            await _book.InsertOneAsync(newBook);

        public async Task UpdateBook(string id, Book updatedBook) =>
            await _book.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task DeleteBook(string id) =>
            await _book.DeleteOneAsync(x => x.Id == id);
    }

    
}