using BooksApp.Core.Localization;
using Honeywell.Portable.Interfaces;
using MvvmCross.Core.ViewModels;

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