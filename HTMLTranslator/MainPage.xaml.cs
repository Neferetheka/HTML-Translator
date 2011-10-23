using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace HTMLTranslator
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        public static string TexteToTranslate;
        public static int index = 0;

        public MainPage()
        {
            InitializeComponent();

            PhoneApplicationService.Current.Activated += new EventHandler<ActivatedEventArgs>(Current_Activated);
            PhoneApplicationService.Current.Launching += new EventHandler<LaunchingEventArgs>(Current_Launching);
        }

        void Current_Launching(object sender, LaunchingEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml"));
        }

        void Current_Activated(object sender, ActivatedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/MainPage.xaml"));        
        }

        private void BeginTranslation(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["texte"] = textBoxTranslation.Text;

            if (radioHT.IsChecked == true)
                index = 0;
            else if (radioTH.IsChecked == true)
                index = 1;

            IsolatedStorageSettings.ApplicationSettings["index"] = index;

            NavigationService.Navigate(new Uri("/Result.xaml?i=" + index, UriKind.Relative));
        }

       
    }
}
