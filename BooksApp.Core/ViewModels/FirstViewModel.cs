using MvvmCross.Core.ViewModels;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace BooksApp.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{ 
        //    get { return _hello; }
        //    set { SetProperty (ref _hello, value); }
        //}

        public string Hello { get; set; } = "Hello MvvmCross";

        [PropertyChanged.DoNotNotify]
        public int NonMod { get; set; }

        public ICommand ShowSecondCommand => new MvxCommand(ShowSecond);

        private void ShowSecond()
        {
            ShowViewModel<SecondViewModel>(new { message = "Coming from FirstViewModel" });
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
