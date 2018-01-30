using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PrayerApp
{
    /* Reference: http://www.c-sharpcorner.com/article/realm-mobile-database-with-xamarin-forms-step-by-step-guide/ */
    public partial class ShowBookItem : ContentPage
    {
        BookItem mSelBookItem;
        public ShowBookItem()
        {
            InitializeComponent();
        }

        public ShowBookItem(BookItem aSelBookItem)
        {
            InitializeComponent();
            mSelBookItem = aSelBookItem;
            BindingContext = mSelBookItem;
        }
    }
}
