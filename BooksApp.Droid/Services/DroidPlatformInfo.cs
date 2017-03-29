using Android.OS;
using Honeywell.Portable.Interfaces;

namespace BooksApp.Droid.Services
{
    public class DroidPlatformInfo : IPlatformInfo
    {
        public string BaseDirectory => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    }
}