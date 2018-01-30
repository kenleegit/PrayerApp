using System;

using Xamarin.Forms;

namespace PrayerApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, storiesPage, aboutPage, bookItemsPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "每日代禱"
                    };
                    storiesPage = new NavigationPage(new StoriesPage())
                    {
                        Title = "聽眾故事"
                    };
                    bookItemsPage = new NavigationPage(new BookItemsPage())
                    {
                        Title = "收藏"
                    };
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "其他"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    storiesPage.Icon = "tab_feed.png";
                    bookItemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";

                    break;
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "每日代禱"
                    };
                    storiesPage = new StoriesPage()
                    {
                        Title = "聽眾故事"
                    };
                    bookItemsPage = new BookItemsPage()
                    {
                        Title = "收藏"
                    };
                    aboutPage = new AboutPage()
                    {
                        Title = "其他"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(storiesPage);
            Children.Add(bookItemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
