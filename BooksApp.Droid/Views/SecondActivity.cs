using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace BooksApp.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondActivity);
        }
    }
}
