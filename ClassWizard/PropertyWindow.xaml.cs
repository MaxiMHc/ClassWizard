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
    /// Logika interakcji dla klasy PropertyWindow.xaml
    /// </summary>
    public partial class PropertyWindow : Window
    {
        public PropertyObject pole = new PropertyObject();

        public PropertyWindow()
        {
            InitializeComponent();
        }

        public PropertyObject GetPole { get => pole; }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            pole.Keywords = new List<string>();
            pole.Name = Name.ToString();
            pole.AccessModifier = this.AccessModifier.SelectionBoxItem.ToString();
            pole.Type = Type.SelectionBoxItem.ToString();
            foreach (CheckBox Keyword in Keywords.Children)
            {
                if (Keyword.IsChecked == true)
                { 
                    pole.Keywords.Add(Keyword.ToString());
                }
            }
            DialogResult = true;
            Close();
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
