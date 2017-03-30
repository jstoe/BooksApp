using Honeywell.Portable.Interfaces;
using MvvmCross.Core.ViewModels;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly ILoginService _loginService;

        private readonly IDialogService _dialogService;

        public LoginViewModel(ILoginService loginService, IDialogService dialogService)
        {
            _loginService = loginService;
            _dialogService = dialogService;

            Username = "TestUser";
            Password = "YouCantSeeMe";
            IsLoading = false;
        }

        public string Username { get; set; }

        public string Password { get; set; }


        public bool IsLoading { get; set; }

        private IMvxCommand _loginCommand;
        public virtual IMvxCommand LoginCommand => _loginCommand ??
            (_loginCommand = new MvxCommand(AttemptLogin, CanExecuteLogin));

        private async void AttemptLogin()
        {
            IsLoading = true;
            await Task.Delay(500);
            if (_loginService.Login(Username, Password))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.Alert("We were unable to log you in!", "Login Failed", "OK");
            }
            IsLoading = false;
        }

        private bool CanExecuteLogin()
        {
            return (!string.IsNullOrEmpty(Username) || !string.IsNullOrWhiteSpace(Username))
                   && (!string.IsNullOrEmpty(Password) || !string.IsNullOrWhiteSpace(Password));
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
}
