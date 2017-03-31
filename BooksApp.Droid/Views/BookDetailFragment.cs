using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using BooksApp.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Views;

namespace BooksApp.Droid.Views
{
    // true im Attribut: Backstack-Eintrag => Back innerhalb der App
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("booksapp.droid.views.BookDetailFragment")]
    public class BookDetailFragment : BaseFragment<BookDetailViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // ShowHamburgerMenu = true;
            // Wenn eingeschaltet, Navigation inkonsistent?
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_detail;
    }
}
