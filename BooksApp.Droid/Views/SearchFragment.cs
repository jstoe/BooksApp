using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using BooksApp.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views;

namespace BooksApp.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("booksapp.droid.views.SearchFragment")]
    public class SearchFragment : BaseFragment<SearchViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_search;
    }
}
