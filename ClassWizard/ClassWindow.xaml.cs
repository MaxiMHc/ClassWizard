using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        public ClassObject MainClassObject { get; private set; }
       
        public ClassWindow()
        {
            
            var acces = new List<string>();
            acces.Add("private");
            acces.Add("protected");
            acces.Add("public");
            InitializeComponent();
            MainClassObject = new ClassObject();
            MainClassObject.Properties = new List<PropertyObject>();
            Class_Pole_List.ItemsSource = MainClassObject.Properties;
            _AccessModifier.ItemsSource= acces;
            _AccessModifier.SelectedIndex = 0;
        }

        private void Pole_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            PropertyWindow _PropertyWindow = new PropertyWindow();
            _PropertyWindow.Owner = this;
            if(_PropertyWindow.ShowDialog() == true)
            {
                MainClassObject.Properties.Add(_PropertyWindow.GetPole);
            }
            else
            {
                // something
            }
            Class_Pole_List.Items.Refresh();
        }

        private void Pole_Edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pole_Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Inter_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Inter_Edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Inter_Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Metoda_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            MethodWindow _MethodWindow = new MethodWindow();
            _MethodWindow.Owner= this;
            if(_MethodWindow.ShowDialog() == true)
            {
                //MainClassObject.Methods.Add(_MethodWindow.Method);
            }
            else
            {
                // something
            }
            _Method_List.Items.Refresh();
        }

        private void Metoda_Edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Metoda_Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {

            MainClassObject.Name = _Name.Text;
            MainClassObject.AccessModifier = _AccessModifier.Text;
            DialogResult = true;
            Close();
        }
    }
}
