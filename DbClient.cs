using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public DbClient(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }
        public IMongoCollection<Book> GetBooksCollection() => _booksCollection;
    }
}
