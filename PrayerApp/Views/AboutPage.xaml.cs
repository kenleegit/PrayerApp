using System;

using Xamarin.Forms;

namespace PrayerApp
{
    public partial class AboutPage : ContentPage
    {
        enum TypesOfPage {url, local};
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnBtnClicked(object sender, System.EventArgs e)
        {
            //2018-01-12 Open pages according to buttons clicked.
            string urlToOpen = "https://prayer.febchk.org/"; //Default page to open.
            var button = (Button)sender;
            int typeOfPage = -1;
            switch (button.Text)
            {
                case "關於我們":
                    urlToOpen = "https://prayer.febchk.org/%E9%81%94%E6%96%A1%E7%88%BE%E6%97%8F/";
                    typeOfPage = (int)TypesOfPage.url;
                    break;
            }
            if (typeOfPage == (int)TypesOfPage.url)
            {
                var modalPage = new ModalPage(urlToOpen);
                await Navigation.PushModalAsync(modalPage);
            } else {
                switch (button.Text)
                {
                    case "聯絡我們":
                        var modalPage = new ContactUsPage();
                        await Navigation.PushModalAsync(modalPage);
                        break;
                }
            }
        }
    }
}
