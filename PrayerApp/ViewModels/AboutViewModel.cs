using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace PrayerApp
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "其他";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.febchk.org/hk/online-donation/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
