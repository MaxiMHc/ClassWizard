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
using System.Windows.Shapes;

namespace ClassWizard
{
    /// <summary>
    /// Logika interakcji dla klasy MethodWindow.xaml
    /// </summary>
    public partial class MethodWindow : Window
    {
        public MethodWindow()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ArgumentWindow _ArgumentWindow = new ArgumentWindow();
            _ArgumentWindow.Owner = this;
            _ArgumentWindow.ShowDialog();
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
