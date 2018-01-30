using System;

using Xamarin.Forms;

namespace PrayerApp
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnBtnClicked(object sender, System.EventArgs e)
        {
            //2018-01-12 Open pages according to buttons clicked.
            string urlToOpen = "https://prayer.febchk.org/"; //Default page to open.
            var button = (Button)sender;
            switch (button.Text)
            {
                case "關於我們":
                    urlToOpen = "https://prayer.febchk.org/%E9%81%94%E6%96%A1%E7%88%BE%E6%97%8F/";
                    break;
                case "聯絡我們":
                    urlToOpen = "https://prayer.febchk.org/%E9%AB%98%E5%B1%B1%E6%97%8F/";
                    break;
            } 
            var modalPage = new ModalPage(urlToOpen);
            await Navigation.PushModalAsync(modalPage);
        }
    }
}
