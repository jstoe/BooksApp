using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using BooksApp.Core.ViewModels;
using BooksApp.Droid.Behaviors;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;

namespace BooksApp.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("booksapp.droid.views.SearchListFragment")]
    public class SearchListFragment : BaseFragment<SearchListViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            var result = base.OnCreateView(inflater, container, savedInstanceState);

            //var view = this.Activity.FindViewById<MvxRecyclerView>(Resource.Id.theList);
            //var itemTouchHelper = new ItemTouchHelper(new Swipe2DismissTouchHelperCallback());
            //itemTouchHelper.AttachToRecyclerView(view);

            return result;
        }

        protected override int FragmentId => Resource.Layout.fragment_searchlist;
    }
}
