﻿using System;
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
using System.ComponentModel;

namespace KF2Tool
{

    public partial class MainWindow : Window
    {
        MapData AllMaps = new MapData();


        public MainWindow()
        {
            InitializeComponent();

            OnlineList.Items.Clear();
            foreach (Map map in AllMaps.MapList)
            {
                ListBoxItem row = new ListBoxItem();
                row.Content = map.MapName;
                OnlineList.Items.Add(row);
            }

            OnlineList.SelectedIndex = 0;
        }

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.paypal.me/korthals");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //test button

        }


        //Code for displaying information of selected item
        private void OnlineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MapName.Content = AllMaps.MapList[OnlineList.SelectedIndex].MapName;
            MapArticle.Text = AllMaps.MapList[OnlineList.SelectedIndex].MapArticle;
            lblAuthor.Content = "Map by: " + AllMaps.MapList[OnlineList.SelectedIndex].Author;
            Screenshot.Source = new BitmapImage(new Uri(AllMaps.MapList[OnlineList.SelectedIndex].PreviewImage));
            levelCount.Content = AllMaps.MapList.Count +" Levels";

        }
    }
}
