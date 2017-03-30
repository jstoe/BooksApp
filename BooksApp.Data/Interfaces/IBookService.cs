using System.Threading.Tasks;

namespace BooksApp.Data.Interfaces
{
    public interface IBookService
    {
        Task<BookQuery> BookQueryAsync(string text);
        Task<Book> GetBookDetailsAsync(string id);

        Task SaveBookAsync(Book book, string userName);
    }
}
