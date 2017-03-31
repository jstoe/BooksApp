using BooksApp.Data.Interfaces;
using Honeywell.Portable.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Services
{
    public class BookService : IBookService
    {
        IRestService m_Rest;
        //IDataService m_DataService;

        public BookService(IRestService rest)//, IDataService data)
        {
            m_Rest = rest;
            //m_DataService = data;
        }

        public async Task<BookQuery> BookQueryAsync(string text)
        {
            var result = await m_Rest.GetDataAsync<BookQuery>
                (string.Format("https://www.googleapis.com/books/v1/volumes?q={0}&maxResults=10", text));

            return result;
        }

        public async Task<Book> GetBookDetailsAsync(string id)
        {
            return await m_Rest.GetDataAsync<Book>
                (string.Format("https://www.googleapis.com/books/v1/volumes/{0}", id));
        }

        public async Task SaveBookAsync(Book book, string userName)
        {
            //await m_DataService.SaveBookAsync(book, userName);
        }

    }
}
