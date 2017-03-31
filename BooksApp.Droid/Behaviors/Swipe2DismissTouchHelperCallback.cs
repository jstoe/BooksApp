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
using Android.Support.V7.Widget.Helper;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using BooksApp.Core.ViewModels;

namespace BooksApp.Droid.Behaviors
{

    // Try to use http://smstuebe.de/2016/05/22/mvvmcross-swipe2dismiss/
    public class Swipe2DismissTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public Swipe2DismissTouchHelperCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Swipe2DismissTouchHelperCallback() : base(0, ItemTouchHelper.Left | ItemTouchHelper.Right)
        {
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            var holder = (MvxRecyclerViewHolder)viewHolder;
            var vm = (ICanDeleteItem)holder.DataContext;
            //vm.DeleteCommand.Execute();
        }
    }
}