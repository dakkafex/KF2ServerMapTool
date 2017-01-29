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
using System.Windows.Media.Animation;

namespace KF2Tool
{

    public partial class MainWindow : Window
    {

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.paypal.me/korthals");
        }

        public MainWindow()
        {

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MapData AllMaps = new MapData();
            foreach (Map map in AllMaps.MapCollection())
            {
                OnlineList.Items.Add(map.MapName);
            }

        }
    }
}
