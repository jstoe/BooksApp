using MvvmCross.Core.ViewModels;

namespace BooksApp.Core.ViewModels
{
    public class WelcomeViewModel : MvxViewModel
    {
        public string Message { get; private set; }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);
        }

        public void Init(string message)
        {
            this.Message = message;
        }
    }
}