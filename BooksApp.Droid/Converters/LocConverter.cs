using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using BooksApp.Core.Localization;
using System.Reflection;

namespace BooksApp.Droid.Converters
{
    public class LocConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "?";
            TryGetPropertyInternal(typeof(Strings), (parameter ?? "").ToString(), out result);
            return result;
        }

        private bool TryGetPropertyInternal(Type type, string name, out string result)
        {
            try
            {
                result = (string)type.GetRuntimeProperty(name).GetValue(null);
                return true;
            }
            catch
            {
                result = "?";
                return false;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}