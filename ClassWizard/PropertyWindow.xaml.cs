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
        public PropertyObject pole { get; set; } 

        public PropertyWindow()
        {
            ClassWindow parent = Application.Current.Windows.OfType<ClassWindow>().FirstOrDefault();
            var accessMod = new BasicDataCollection();
            InitializeComponent();
            this.AccessModifier.ItemsSource = accessMod.Modifiers;
            this.Type.ItemsSource = accessMod.DataTypes;
           
            if (parent.Class_Pole_List.SelectedIndex != -1)
            {
                pole = parent.MainClassObject.Properties[parent.Class_Pole_List.SelectedIndex];
                this._Name.Text = pole.Name;
                this.AccessModifier.SelectedItem = pole.AccessModifier;
                this.Type.SelectedItem = pole.Type;
               foreach (string keyword in pole.Keywords)
               {
                    foreach (CheckBox chk in Keywords.Children)
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
                pole = new PropertyObject();
                this.AccessModifier.SelectedIndex = 0;
                this.Type.SelectedIndex = 0;
            }
            
            
        }

        public PropertyObject GetPole { get => pole; }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //pole.Keywords = new List<string>();
            pole.Name = _Name.Text;
            pole.AccessModifier = this.AccessModifier.Text;
            pole.Type = Type.Text;
            pole.Keywords = new List<string>();
            foreach (CheckBox Keyword in Keywords.Children)
            {
                if (Keyword.IsChecked == true)
                { 
                    pole.Keywords.Add(Keyword.Content.ToString());
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
