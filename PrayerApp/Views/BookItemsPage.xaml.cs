using Realms;  
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;  
using Xamarin.Forms;

namespace PrayerApp
{
    /* Reference: http://www.c-sharpcorner.com/article/realm-mobile-database-with-xamarin-forms-step-by-step-guide/ */
    public partial class BookItemsPage : ContentPage
    {
        public BookItemsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()  
        {  
            base.OnAppearing();  
            var vRealmDb = Realm.GetInstance();  
            var vAllEmployees = vRealmDb.All<BookItem>();  
            lstData.ItemsSource = vAllEmployees;  
        } 

        void OnSelection(object sender, SelectedItemChangedEventArgs e)  
        {  
            if (e.SelectedItem == null)  
            {  
                return;  
                //ItemSelected is called on deselection,   
                //which results in SelectedItem being set to null  
            }  
            var vSelBookItem = (BookItem)e.SelectedItem;  
            Navigation.PushAsync(new ShowBookItem(vSelBookItem));  
        }  
    }
}
