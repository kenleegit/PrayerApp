using System;

namespace PrayerApp
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string id { get; set; }
        public string date { get; set; }
        public Title title { get; set; }
        public content content { get; set; }
        public content excerpt { get; set; }
        //Reference: https://stackoverflow.com/questions/24496941/deserialisation-of-a-nested-json-object-with-newtonsoft-in-c-sharp
    }
}
