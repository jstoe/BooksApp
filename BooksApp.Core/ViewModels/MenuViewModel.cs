using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace BooksApp.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public ICommand ShowHomeCommand => new MvxCommand(() => ShowViewModel<WelcomeViewModel>());

        public ICommand ShowResearchCommand => new MvxCommand(() => ShowViewModel<SearchViewModel>());

        public ICommand ShowResearchListCommand => new MvxCommand(() => ShowViewModel<SearchListViewModel>());
    }
}