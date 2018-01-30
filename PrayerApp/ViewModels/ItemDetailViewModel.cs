using System;

namespace PrayerApp
{
    public class ItemDetailViewModel : BaseViewModel
    {
        //public event EventHandler<BIEventArgs> BookAnItemEvent;
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
