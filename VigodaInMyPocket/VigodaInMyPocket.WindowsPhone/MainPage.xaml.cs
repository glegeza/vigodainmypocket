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
        private BitmapImage confusedImage;
        private BitmapImage aliveImage;
        private BitmapImage deadImage;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            confusedImage = new BitmapImage(new Uri(@"ms-appx:///loadgoda.png", UriKind.RelativeOrAbsolute));
            aliveImage = new BitmapImage(new Uri(@"ms-appx:///vigoda.jpg", UriKind.RelativeOrAbsolute));
            deadImage = new BitmapImage(new Uri(@"ms-appx:///vigoda.jpg", UriKind.RelativeOrAbsolute));
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
            
            UpdateContent();
        }

        async private void UpdateContent()
        {
            SetChecking();

            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync("http://www.abevigoda.com");
            var webresponse = await response.Content.ReadAsStringAsync();
            if (webresponse.IndexOf("alive") != -1)
            {
                SetAlive();
            }
            else
            {
                SetDead();
            }
        }

        private void SetChecking()
        {
            vigodaImage.Source = confusedImage;
            vigodaStatus.Text = " ???";
        }

        private void SetAlive()
        {
            BitmapImage bm = aliveImage;
            vigodaImage.Source = bm;
            vigodaStatus.Text = "Alive";
        }

        private void SetDead()
        {
            BitmapImage bm = deadImage;
            vigodaImage.Source = bm;
            vigodaStatus.Text = "Dead";
            vigodaStatus.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
        }
    }
}
