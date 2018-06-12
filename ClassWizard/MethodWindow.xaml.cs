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
using System.Windows.Shapes;

namespace ClassWizard
{
    /// <summary>
    /// Logika interakcji dla klasy MethodWindow.xaml
    /// </summary>
    public partial class MethodWindow : Window
    {
        public MethodObject Method { get; set; }
        public MethodWindow()
        {
            ClassWindow parent = Application.Current.Windows.OfType<ClassWindow>().FirstOrDefault();
            var accessMod = new BasicDataCollection();
            InitializeComponent();
            _Access.ItemsSource = accessMod.Modifiers;
            _Type.ItemsSource = accessMod.DataTypes;
            if (parent._Method_List.SelectedIndex != -1)
            {
                Method = parent.MainClassObject.Methods[parent._Method_List.SelectedIndex];
                this._Name.Text = Method.Name;
                _Arguments.ItemsSource = Method.Arguments;
                _Access.SelectedItem = Method.AccessModifier;
                _Type.SelectedItem = Method.ReturnType;
            }
            else
            {
                Method = new MethodObject();
                _Arguments.ItemsSource = Method.Arguments;
                _Access.SelectedIndex = 0;
                _Type.SelectedIndex = 0;
            }
        }

        public MethodObject GetPole { get => Method; }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            _Arguments.SelectedIndex = -1;
            ArgumentWindow _ArgumentWindow = new ArgumentWindow();
            //_ArgumentWindow.Owner = this;
            if(_ArgumentWindow.ShowDialog() == true)
            {
                Method.Arguments.Add(_ArgumentWindow.NewArgument);
            }
            _Arguments.Items.Refresh();
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            if (_Arguments.SelectedIndex != -1)
            {
                ArgumentWindow _ArgumentWindow = new ArgumentWindow();
                //_ArgumentWindow.Owner = this;
                if (_ArgumentWindow.ShowDialog() == true)
                {
                    Method.Arguments[_Arguments.SelectedIndex] = _ArgumentWindow.NewArgument;
                }
                _Arguments.Items.Refresh();
            }
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zatwierdz_Method_Click(object sender, RoutedEventArgs e)
        {
            Method.Name = _Name.Text;
            Method.ReturnType = _Type.Text;
            Method.AccessModifier = _Access.Text;
            Method.ReturnType = _Type.Text; 
            DialogResult = true;
            this.Close();
        }
    }
}
