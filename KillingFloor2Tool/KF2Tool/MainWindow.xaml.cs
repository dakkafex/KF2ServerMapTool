using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace KF2Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 1;
        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.paypal.me/korthals");
        }

        public MainWindow()
        {
            InitializeComponent();
        }



        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //This sets the information.
            string ScreenshotURL;
            string NameMap;
            string Author;
            string Summary;

            
                //    string htmlCode = client.DownloadString("http://kf2.gamebanana.com/maps/188863");

                //    NameMap = Regex.Match(htmlCode, @"<title>(.+?) ", RegexOptions.Singleline).Groups[1].Value;
                //    ScreenshotURL = Regex.Match(htmlCode, @"<a class=\u0022Screenshot\u0022 href=\u0022(.+?).jpg\u0022>", RegexOptions.Singleline).Groups[1].Value + ".jpg";
                //    AuthorST = Regex.Match(htmlCode, @"This is a Map submitted by(.+?)for", RegexOptions.Singleline).Groups[1].Value;
                //    Author = Regex.Match(AuthorST, @"\u0022>(.+?)</a>", RegexOptions.Singleline).Groups[1].Value;
                //    Summary = Regex.Match(htmlCode, @"<strong>Summary\u003A</strong></p><p>(.+?)</p>", RegexOptions.Singleline).Groups[1].Value;
                //}

                var response = WebRequest.Create("http://kf2.gamebanana.com/maps?api=SubmissionsListModule").GetResponse();
                var strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Rootobject resObject = JsonConvert.DeserializeObject<Rootobject>(strResponse);
                //dynamic resObject = JsonConvert.DeserializeObject(strResponse);
                //foreach (var cellVal in resObject._aCellValues)
                //{
                //    Console.WriteLine(String.Format("Map: {0}, submitted by {1}\n", cellVal._sName, cellVal._aSubmitter._sUsername));
                //}


                NameMap = resObject._aCellValues[x]._sName;
                Author = resObject._aCellValues[x]._aSubmitter._sUsername;
                Summary = resObject._aCellValues[x]._sArticle;
                ScreenshotURL = resObject._aCellValues[x]._sFirstThumbnailImageUrl;

                //MapName.Content = NameMap;
                lblAuthor.Content = $"Map by: {Author}.";
                //summary.Text = Summary;
                Screenshot.Source = new BitmapImage(new Uri(ScreenshotURL));

            

        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            x++;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var info = GetInfo();
            foreach (var item in info._aCellValues)
                OnlineList.Items.Add(item);
        }
        
        /// <summary>
        /// Gets the maps info from the server
        /// </summary>
        /// <returns></returns>
        private Rootobject GetInfo()
        {
            var response = WebRequest.Create("http://kf2.gamebanana.com/maps?api=SubmissionsListModule").GetResponse();
            var strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<Rootobject>(strResponse);
        }

        private void OnlineList_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item =
                ItemsControl.ContainerFromElement(OnlineList, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                var infoBits = item.Content as _Acellvalues;
                lblAuthor.Content = $"Map by: {infoBits._aSubmitter._sUsername}.";
                Summary.NavigateToString(infoBits._sArticle);
                Screenshot.Source = new BitmapImage(new Uri(infoBits._sFirstThumbnailImageUrl));
            }
        }
    }
}
