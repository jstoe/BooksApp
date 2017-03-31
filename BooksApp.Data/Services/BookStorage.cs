using BooksApp.Data.Interfaces;
using Honeywell.Portable.Interfaces;
using MvvmCross.Platform;
using MvvX.Plugins.CouchBaseLite;
using MvvX.Plugins.CouchBaseLite.Database;
using System.IO;
using System;
using Newtonsoft.Json;

namespace BooksApp.Data.Services
{
    public class BookStorage : IBookStorage
    {
        private IDatabase m_DataBase;
        private ISettingsService m_SettingsService;

        public BookStorage(IPlatformInfo platform, ICouchBaseLite couchbase, ISettingsService settingsService)
        {
            // Connect to the database
            couchbase.Initialize(platform.BaseDirectory);
            couchbase.ManageLog(false);
            var options = couchbase.CreateDatabaseOptions();
            options.Create = true;
            m_DataBase = couchbase.CreateConnection("bookscouchdb", options);
            m_SettingsService = settingsService;
        }

        public void SaveBook(Book currentBook)
        {
            var entry = new BookEntry { Book = currentBook, UserName = m_SettingsService.Get<string>("UserName") };
            var doc = m_DataBase.CreateDocument();
            doc.Update(rev =>
            {
                rev.SetUserProperties(entry.ToDictionary());
                return true;
            });
        }
    }
}
