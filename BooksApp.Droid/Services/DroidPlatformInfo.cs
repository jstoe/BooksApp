using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Honeywell.Portable.Interfaces;

namespace BooksApp.Droid.Services
{
    public class DroidPlatformInfo : IPlatformInfo
    {
        public string BaseDirectory => Android.OS.Environment.DirectoryDocuments;
    }
}