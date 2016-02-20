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

namespace KF2Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //This sets the information
            string ScreenshotURL;
            string NameMap;
            string AuthorST;
            string Author;
            string Summary;

            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString("http://kf2.gamebanana.com/maps/188863");

                NameMap = Regex.Match(htmlCode, @"<title>(.+?) ", RegexOptions.Singleline).Groups[1].Value;
                ScreenshotURL = Regex.Match(htmlCode, @"<a class=\u0022Screenshot\u0022 href=\u0022(.+?).jpg\u0022>", RegexOptions.Singleline).Groups[1].Value + ".jpg";
                AuthorST = Regex.Match(htmlCode, @"This is a Map submitted by(.+?)for", RegexOptions.Singleline).Groups[1].Value;
                Author = Regex.Match(AuthorST, @"\u0022>(.+?)</a>", RegexOptions.Singleline).Groups[1].Value;
                Summary = Regex.Match(htmlCode, @"<strong>Summary\u003A</strong></p><p>(.+?)</p>", RegexOptions.Singleline).Groups[1].Value;
            }

            MapName.Content = NameMap;
            lblAuthor.Content = $"Map by: {Author}.";
            summary.Text = Summary;
            Screenshot.Source = new BitmapImage(new Uri(ScreenshotURL));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
