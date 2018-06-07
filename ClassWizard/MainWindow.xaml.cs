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

namespace ClassWizard
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ClassObject> Classes { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Classes = new List<ClassObject>();
            _Class_List.ItemsSource = Classes;

            List<string> kw = new List<string>();
            kw.Add("const");
            //kw.Add("key2");
            //kw.Add("key3");

            ArgumentObject ao = new ArgumentObject
            {
                Name = "Name",
                Type = "type",
                Keywords = kw
            };

            PropertyObject po = new PropertyObject
            {
                Name = "Name",
                Type = "int",
                AccessModifier = "public",
                Keywords = kw
            };

            List<ArgumentObject> aol = new List<ArgumentObject>();
            aol.Add(ao);
            aol.Add(ao);
            aol.Add(ao);
            aol.Add(ao);

            MethodObject mo = new MethodObject
            {
                Name = "Method",
                AccessModifier = "public",
                ReturnType = "string",
                Arguments = aol,
                Keywords = kw
            };

            //MessageBox.Show("normal\n" + "\ttabbed\n" + mo.ToFinalString());

            List<MethodObject> mol = new List<MethodObject>();
            mol.Add(mo);
            mol.Add(mo);
            mol.Add(mo);
            mol.Add(mo);

            List<string> i = new List<string>();
            i.Add("interface1");
            i.Add("interface2");
            i.Add("interface3");

            List<PropertyObject> pol = new List<PropertyObject>();
            pol.Add(po);
            pol.Add(po);
            pol.Add(po);

            ClassObject co = new ClassObject
            {
                Name = "KLASA",
                Keywords = kw,
                AccessModifier = "public",
                Inheritance = "INNAKLASA",
                Interfaces = i,
                Methods = mol,
                Properties = pol
            };

            //MessageBox.Show(co.ToFinalString());

            Preview_TextBox.Text = co.ToFinalString();

            //this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ClassWindow _ClassWindow = new ClassWindow();
            _ClassWindow.Owner = this;
            _ClassWindow.ShowDialog();
            if(_ClassWindow.DialogResult == true)
            {
                Classes.Add(_ClassWindow.MainClassObject);
                //Dalej wpisac na liste
            }
            _Class_List.Items.Refresh();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            //TODO MATE
             //Deleted from World Mate
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            //TODO PAL
            //Edited World Pal
        }

        private void _Class_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Preview_TextBox.Text = Classes[_Class_List.SelectedIndex].ToFinalString();
        }
    }
}
