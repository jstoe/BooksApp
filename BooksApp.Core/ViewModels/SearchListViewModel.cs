using BooksApp.Data;
using BooksApp.Data.Interfaces;
using BooksApp.Data.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;
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
        private PortableChat m_Chat;

        public SearchListViewModel(IBookStorage bookStorage)
        {
            m_BookStorage = bookStorage;
        }

        public ICollection<BookEntry> Books { get; private set; }

        public bool IsLoading { get; set; } = true;

        public ICommand DeleteCommand => new MvxCommand<BookEntry>(DeleteItem);
        public ICommand ShareCommand => new MvxCommand<BookEntry>(ShareItem);

        private async void ShareItem(BookEntry entry)
        {
            await m_Chat.Send(JsonConvert.SerializeObject(entry));
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            IsLoading = true;
            base.InitFromBundle(parameters);
            InitChat();
            LoadBooks();
        }

        private async void InitChat()
        {
            m_Chat = new PortableChat();
            if (await m_Chat.Connect("http://www.adaxer.de/signalr/hubs"))
                m_Chat.Receive += OnReceiveShared; ;
        }

        private void OnReceiveShared(string json)
        {
            try
            {
                var entry = JsonConvert.DeserializeObject<BookEntry>(json);
                if (!Books.Any(b => b.Id == entry.Id))
                    Books.Add(entry);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.Message);
            }
        }

        private async void LoadBooks()
        {
            Books = new MvxObservableCollection<BookEntry>(await m_BookStorage.LoadBooksAsync());
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
