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
    /// Logika interakcji dla klasy ArgumentWindow.xaml
    /// </summary>
    public partial class ArgumentWindow : Window
    {
        public ArgumentObject NewArgument { get; private set; }
        public ArgumentWindow()
        {
            MethodWindow parent = Application.Current.Windows.OfType<MethodWindow>().FirstOrDefault();
            var accessMod = new BasicDataCollection();
            
            InitializeComponent();
            this._TypeArg.ItemsSource = accessMod.DataTypes;
            if (parent._Arguments.SelectedIndex != -1)
            {
                NewArgument = parent.Method.Arguments[parent._Arguments.SelectedIndex];
                this._Name.Text = NewArgument.Name;
                this._TypeArg.SelectedItem = NewArgument.Type;
                foreach (string keyword in NewArgument.Keywords)
                {
                    foreach (CheckBox chk in _Keywords.Children)
                    {
                        if (keyword == chk.Content.ToString())
                        {
                            chk.IsChecked = true;
                        }
                    }
                }
            }
            else
            {
                NewArgument = new ArgumentObject();
                this._TypeArg.SelectedIndex = 0;
            }
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (_Name.Text == "" || _Name.Text == null)
            {
                MessageBox.Show("Argument musi posiadać nazwę", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MethodWindow mainw = Application.Current.Windows.OfType<MethodWindow>().FirstOrDefault();

            foreach (ArgumentObject Item in mainw.Method.Arguments)
            {
                if (_Name.Text == Item.Name)
                {
                    MessageBox.Show("Argument o danej nazwie już istnieje", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            NewArgument.Name = _Name.Text;
            NewArgument.Type = _TypeArg.Text;
            NewArgument.Keywords = new List<string>();
            foreach (CheckBox Keyword in _Keywords.Children)
            {
                if (Keyword.IsChecked == true)
                {
                    NewArgument.Keywords.Add(Keyword.Content.ToString());
                }
            }
            DialogResult = true;
            Close();
        }
    }
}
