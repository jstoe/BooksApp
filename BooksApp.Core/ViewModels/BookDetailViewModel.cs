using BooksApp.Data;
using BooksApp.Data.Interfaces;
using MvvmCross.Core.ViewModels;

namespace BooksApp.Core.ViewModels
{
    public class BookDetailViewModel : MvxViewModel
    {
        private IBookService m_BookService;

        public BookDetailViewModel(IBookService bookService)
        {
            m_BookService = bookService;
        }

        public Book CurrentBook { get; set; }

        public bool IsLoading { get; set; } = true;

        public async void Init(string id)
        {
            CurrentBook = await m_BookService.GetBookDetailsAsync(id);
            IsLoading = false;
        }
    }
}