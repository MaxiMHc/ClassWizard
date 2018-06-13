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
        private MainWindow main = ((MainWindow)Application.Current.MainWindow);

        public ClassWindow()
        {

            var accessMod = new BasicDataCollection();

            InitializeComponent();

            if (main._Class_List.SelectedIndex != -1)
            {
                MainClassObject = main.Classes[main._Class_List.SelectedIndex];
                _Name.Text = MainClassObject.Name;
                _InheritanceCheckBox.IsChecked = true;
                _InheritanceTextBox.Text = MainClassObject.Inheritance;
                _AccessModifier.ItemsSource = accessMod.Modifiers;
                _AccessModifier.SelectedItem = MainClassObject.AccessModifier;
                foreach(string keyword in MainClassObject.Keywords)
                {
                    foreach(CheckBox chk in _KeyWords.Children)
                    {
                        if(keyword == chk.Content.ToString())
                        {
                            chk.IsChecked = true;
                        }
                    }
                }

                if(MainClassObject.Interfaces.Count != 0)
                {
                    _InterfaceCheckBox.IsChecked = true;
                }
            }
            else
            {
                MainClassObject = new ClassObject();
                _AccessModifier.ItemsSource = accessMod.Modifiers;
                _AccessModifier.SelectedIndex = 0;
            }

            Class_Pole_List.ItemsSource = MainClassObject.Properties;
            _Method_List.ItemsSource = MainClassObject.Methods;
            
            _ImplementedInterfaces.ItemsSource = MainClassObject.Interfaces;
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
            if (Class_Pole_List.SelectedIndex != -1)
            {
                PropertyWindow _PropertyWindow = new PropertyWindow();
               // _PropertyWindow.Owner = this;
                if (_PropertyWindow.ShowDialog() == true)
                {
                    MainClassObject.Properties[Class_Pole_List.SelectedIndex] =_PropertyWindow.GetPole;
                }
                else
                {
                    // something
                }
                Class_Pole_List.Items.Refresh();
            }
        }

        private void Pole_Usun_Click(object sender, RoutedEventArgs e)
        {
            if(Class_Pole_List.SelectedIndex != -1)
            {
                MainClassObject.Properties.RemoveAt(Class_Pole_List.SelectedIndex);
            }
            Class_Pole_List.Items.Refresh();
        }

        private void Inter_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            _ImplementedInterfaces.SelectedIndex = -1;
            MainClassObject.Interfaces.Add(_InterfaceTextBox.Text);
            _InterfaceTextBox.Text = "";
            _ImplementedInterfaces.Items.Refresh();
        }

        private void Inter_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            if(_ImplementedInterfaces.SelectedIndex !=-1)
            {
                MainClassObject.Interfaces[_ImplementedInterfaces.SelectedIndex] = _InterfaceTextBox.Text;
            }
            _ImplementedInterfaces.Items.Refresh();
        }

        private void Inter_Usun_Click(object sender, RoutedEventArgs e)
        {
            if(_ImplementedInterfaces.SelectedIndex !=-1)
            {
                MainClassObject.Interfaces.RemoveAt(_ImplementedInterfaces.SelectedIndex);
            }
            _ImplementedInterfaces.Items.Refresh();
        }

        private void Metoda_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            _Method_List.SelectedIndex = -1;
            MethodWindow _MethodWindow = new MethodWindow();
          //  _MethodWindow.Owner= this;
            if(_MethodWindow.ShowDialog() == true)
            {
                MainClassObject.Methods.Add(_MethodWindow.GetPole);
            }
            else
            {
                // something
            }
            _Method_List.Items.Refresh();
        }

        private void Metoda_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            MethodWindow _MethodWindow = new MethodWindow();
            //  _MethodWindow.Owner= this;
            if (_MethodWindow.ShowDialog() == true)
            {
                MainClassObject.Methods[_Method_List.SelectedIndex] = _MethodWindow.GetPole;
            }
            else
            {
                // something
            }
            _Method_List.Items.Refresh();
        }

        private void Metoda_Usun_Click(object sender, RoutedEventArgs e)
        {
            if(_Method_List.SelectedIndex !=-1)
            {
                MainClassObject.Methods.RemoveAt(_Method_List.SelectedIndex);
            }
            _Method_List.Items.Refresh();
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(_InheritanceCheckBox.IsChecked == true)
            {
                MainClassObject.Inheritance = _InheritanceTextBox.Text;
            }
            MainClassObject.Name = _Name.Text;
            MainClassObject.AccessModifier = _AccessModifier.Text;
            MainClassObject.Keywords = new List<string>();
            foreach(CheckBox keyword in _KeyWords.Children)
            {
                if(keyword.IsChecked == true)
                {
                    MainClassObject.Keywords.Add(keyword.Content.ToString());
                }
            }
            DialogResult = true;
            Close();
        }


        private void _ImplementedInterfaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_ImplementedInterfaces.SelectedIndex != -1)
            _InterfaceTextBox.Text = MainClassObject.Interfaces[_ImplementedInterfaces.SelectedIndex];
        }

        private void UpCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox Argument_List = (ListBox)e.Parameter;
            if (!(Argument_List == null))
            {
                if (Argument_List.SelectedIndex > 0)
                    e.CanExecute = true;
                else
                    e.CanExecute = false;
            }
        }

        private void UpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox Argument_List = (ListBox)e.Parameter;
            if (!(Argument_List == null))
            {
                Argument_List.SelectedIndex--;
            }
        }
        private void DownCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox Argument_List = (ListBox)e.Parameter;
            if (!(Argument_List == null))
            {
                if (Argument_List.SelectedIndex != (Argument_List.Items.Count - 1))
                    e.CanExecute = true;
                else
                    e.CanExecute = false;
            }
        }

        private void DownExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox Argument_List = (ListBox)e.Parameter;
            if (!(Argument_List == null))
            {
                Argument_List.SelectedIndex++;
            }
        }

        
    }
}
