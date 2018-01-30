using Realms;
namespace PrayerApp
{
    public class BookItem : RealmObject
    {
        [PrimaryKey]
        public long BIId { get; set; }
        public string BITitle { get; set; }
        public string BIContent { get; set; }
    }
}
