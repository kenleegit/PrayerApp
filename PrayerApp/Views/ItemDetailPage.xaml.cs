using Realms;
using System;
using System.Linq; 
using Xamarin.Forms.Xaml;  
using Xamarin.Forms;

namespace PrayerApp
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;

            //2018-01-09 Tried PinchGesture but no effect
            //var pinchGesture = new PinchGestureRecognizer();
            //pinchGesture.PinchUpdated += (s, e) => {
            //    // Handle the pinch
            //    OnPinchUpdated(s, e);
            //};
            //textContentrendered.GestureRecognizers.Add(pinchGesture);
            //2018-01-09 Tried PinchGesture but no effect
        }

        async void Save_Clicked (object sender, EventArgs e)
        {
            var vRealmDb = Realm.GetInstance();  
            var vBIId = vRealmDb.All<BookItem>().Count() + 1;
            var vBookItem = new BookItem()
            {
                BIId = vBIId,
                BITitle = textTitlerendered.Text,
                BIContent = textContentrendered.Text
            };  
            vRealmDb.Write(() => {  
                vBookItem = vRealmDb.Add(vBookItem);  
            });
            Console.WriteLine("btnSaveClicked");
            await DisplayAlert("", "已收藏", "確定");
        }
        void OnFontSizeSliderChanged (Object sender, EventArgs e){
            var fontSizeValue = sliderFontSize.Value;
            textContentrendered.FontSize = fontSizeValue;
            labelScale.Text = fontSizeValue.ToString();
        }

        //2018-01-09 Tried PinchGesture but no effect
        //double currentScale = 1;
        //double startScale = 1;
        //void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        //{
        //    var s = (ContentView)sender;

        //    if (e.Status == GestureStatus.Started)
        //    {
        //        // Store the current scale factor applied to the wrapped user interface element,
        //        // and zero the components for the center point of the translate transform.
        //        startScale = s.Content.Scale;
        //    }
        //    if (e.Status == GestureStatus.Running)
        //    {

        //        // Calculate the scale factor to be applied.
        //        currentScale += (e.Scale - 1) * startScale;
        //        currentScale = Math.Max(1, currentScale);
        //        currentScale = Math.Min(currentScale, 5);

        //        labelScale.Text = "Scale: " + currentScale.ToString ();
        //    }
        //}
        //2018-01-09 Tried PinchGesture but no effect

        //2018-01-04 Save preference.
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Application.Current.Properties["fontSizeValue"] = sliderFontSize.Value;

        }

        protected override void OnAppearing()
        {
            RestorePreferences();
            Console.WriteLine(textTitlerendered.Text);
            base.OnAppearing();
        }
        //2018-01-04 Restore saved preferences. Todo find where it should be triggered.
        protected void RestorePreferences()
        {
            if (Application.Current.Properties.ContainsKey("fontSizeValue"))
            {
                var fontSizeValue = Application.Current.Properties["fontSizeValue"].ToString();
                textContentrendered.FontSize = double.Parse(fontSizeValue);
                sliderFontSize.Value = double.Parse(fontSizeValue);
            }
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
