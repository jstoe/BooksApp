using BooksApp.Data;
using BooksApp.Data.Interfaces;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System.Windows.Input;
using System;

namespace BooksApp.Core.ViewModels
{
    public class BookDetailViewModel : MvxViewModel
    {
        private IBookService m_BookService;
        private IBookStorage m_BookStorage;

        public BookDetailViewModel(IBookService bookService, IBookStorage bookStorage)
        {
            m_BookService = bookService;
            m_BookStorage = bookStorage;
        }

        public Book CurrentBook { get; set; }

        public bool IsLoading { get; set; } = true;

        public ICommand SaveCommand => new MvxCommand(Save);

        private void Save()
        {
            m_BookStorage.SaveBook(CurrentBook);
        }

        public void Init(string book)
        {
            CurrentBook = JsonConvert.DeserializeObject<Book>(book);
            IsLoading = false;
        }
    }
}