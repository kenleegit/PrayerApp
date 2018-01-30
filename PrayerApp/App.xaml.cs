using System;

using Xamarin.Forms;

namespace PrayerApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        //public static string BackendUrl = "http://localhost:8887";
        public static string BackendUrl = "https://prayer.febchk.org";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
