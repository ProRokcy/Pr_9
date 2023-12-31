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

namespace ARVpr7.Pages.PageManagerLB
{
    /// <summary>
    /// Логика взаимодействия для MainPageManager.xaml
    /// </summary>
    public partial class MainPageManager : Page
    {
        public MainPageManager()
        {
            InitializeComponent();
        }

        private void RegPage_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new RegViewPageMgLB());
        }

        private void ReaderView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new ReaderViewPageMgLB());
        }

        private void BookView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new BookViewPageMgLB());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new PageLogin());
        }
    }
}
