using BooksApp.Data;
using BooksApp.Data.Interfaces;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using Newtonsoft.Json;

namespace BooksApp.Core.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private IBookService m_BookService;

        public SearchViewModel(IBookService bookService)
        {
            m_BookService = bookService;
        }

        public bool IsSearching { get; private set; }

        public string SearchText { get; set; } = "Mvvm";

        public ICollection<Book> Books { get; set; }

        public Book CurrentBook { get; set; }

        public ICommand StartSearchCommand => new MvxCommand(StartSearch, () => !IsSearching);

        public ICommand SelectCommand => new MvxCommand<Book>(BookSelected);

        private void BookSelected(Book book)
        {
            CurrentBook = book;
            if (CurrentBook != null)
                ShowViewModel<BookDetailViewModel>(new { book = JsonConvert.SerializeObject(CurrentBook) });
        }

        private async void StartSearch()
        {
            IsSearching=true;
            var query = await m_BookService.BookQueryAsync(SearchText);
            Books = query?.Books;
            IsSearching = false;
        }

    }
}