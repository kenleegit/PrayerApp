using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PrayerApp
{
    public partial class ContactUsPage : ContentPage
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
