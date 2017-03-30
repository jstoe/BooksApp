using MvvmCross.Core.ViewModels;

namespace BooksApp.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<WelcomeViewModel>();
            ShowViewModel<MenuViewModel>();
        }

        public void ShowHome()
        {
            ShowViewModel<WelcomeViewModel>();
        }

        public void Init(object hint)
        {
            // Can perform Vm data retrival here based on any
            // data passed in the hint object

            // ShowViewModel<SomeViewModel>(new { derp: "herp", durr: "derrrrrr" });
            // public class SomeViewModel : MvxViewModel
            // {
            //     public void Init(string derp, string durr)
            //     {
            //     }
            // }
        }
    }
}
