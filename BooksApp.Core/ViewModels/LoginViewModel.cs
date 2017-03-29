using MvvmCross.Core.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

namespace BooksApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{ 
        //    get { return _hello; }
        //    set { SetProperty (ref _hello, value); }
        //}

        public LoginViewModel()
        {

        }
        public string Hello { get; set; } = "Hello MvvmCross";

        [PropertyChanged.DoNotNotify]
        public int NonMod { get; set; }

        public ICommand ShowSecondCommand => new MvxCommand(ShowSecond);

        private void ShowSecond()
        {
            ShowViewModel<WelcomeViewModel>(new { message = "Coming from FirstViewModel" });
        }

        void Login()
        {

            //var auth = new OAuth2Authenticator(
            //    clientId: "App ID from https://developers.facebook.com/apps",
            //    scope: "",
            //    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
            //    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            //auth.Completed += (sender, eventArgs) =>
            //{
            //    if (eventArgs.IsAuthenticated)
            //    {
            //        // Use eventArgs.Account to do wonderful things
            //    }
            //};
            //auth.
        }
    }

    public class A : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }

    [PropertyChanged.ImplementPropertyChanged]
    public class B
    {
        public string Name { get; set; }
    }
}
