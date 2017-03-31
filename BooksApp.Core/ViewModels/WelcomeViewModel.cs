using BooksApp.Core.Localization;
using BooksApp.Data.Interfaces;
using BooksApp.Data.Services;
using Honeywell.Portable.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace BooksApp.Core.ViewModels
{
    public class WelcomeViewModel : MvxViewModel
    {
        public string User { get; private set; }

        public WelcomeViewModel(ISettingsService settings)
        {
            User = settings.Get<string>("UserName");
        }
    }
}