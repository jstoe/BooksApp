using BooksApp.Data;
using BooksApp.Data.Interfaces;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksApp.Core.ViewModels
{
    public class SearchListViewModel : MvxViewModel, ICanDeleteItem
    {
        private IBookStorage m_BookStorage;

        public SearchListViewModel(IBookStorage bookStorage)
        {
            m_BookStorage = bookStorage;
        }

        public ICollection<BookEntry> Books { get; private set; }

        public bool IsLoading { get; set; } = true;

        public ICommand DeleteCommand => new MvxCommand<BookEntry>(DeleteItem);

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            IsLoading = true;
            base.InitFromBundle(parameters);
            LoadBooks(); 
        }

        private async void LoadBooks()
        {
            Books = new List<BookEntry>(await m_BookStorage.LoadBooksAsync());
            IsLoading = false;
        }

        private void DeleteItem(BookEntry item)
        {
            InvokeOnMainThread(() => Books.Remove(item));
        }
    }

    public interface ICanDeleteItem
    {
        ICommand DeleteCommand { get; }
    }
}
