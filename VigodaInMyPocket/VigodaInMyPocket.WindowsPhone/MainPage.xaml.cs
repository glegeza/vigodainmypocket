using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VigodaInMyPocket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            vigodaImage.Source = new BitmapImage(new Uri(@"ms-appx:///loadgoda.png", UriKind.RelativeOrAbsolute));
            vigodaStatus.Text = " ???";
            UpdateContent();
        }

        async private void UpdateContent()
        {
            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync("http://www.abevigoda.com");
            var webresponse = await response.Content.ReadAsStringAsync();
            if (webresponse.IndexOf("alive") != -1)
            {
                BitmapImage bm = new BitmapImage(new Uri(@"ms-appx:///vigoda.jpg", UriKind.RelativeOrAbsolute));
                vigodaImage.Source = bm;
                vigodaStatus.Text = "Alive";
            }
            else
            {
                BitmapImage bm = new BitmapImage(new Uri(@"ms-appx:///vigoda.jpg", UriKind.RelativeOrAbsolute));
                vigodaImage.Source = bm;
                vigodaStatus.Text = "Dead";
                vigodaStatus.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }
    }
}
