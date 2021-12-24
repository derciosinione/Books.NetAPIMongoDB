using System.Collections.Generic;
using MongoDB.Driver;
using MongoDBBooksApi.Models;

namespace MongoDBBooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }
        
        public List<Book> Get() => _books.Find(book => true).ToList();
        
        public Book Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();
    }
}