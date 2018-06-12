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
            }
            else
            {
                NewArgument = new ArgumentObject();
                this._TypeArg.SelectedIndex = 0;
            }
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            NewArgument.Name = _Name.Text;
            NewArgument.Type = _TypeArg.Text;
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
