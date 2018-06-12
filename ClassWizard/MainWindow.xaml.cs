using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
                Type = "class",
                Keywords = kw,
                AccessModifier = "public",
                Inheritance = "INNAKLASA",
                Interfaces = i,
                Methods = mol,
                Properties = pol
            };

            //MessageBox.Show(co.ToFinalString());

            Preview_TextBox.Text = co.ToFinalString();

            Classes.Add(co);
            Classes.Add(co);
            Classes.Add(co);

            _Class_List.ItemsSource = Classes;

            //this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            _Class_List.SelectedIndex = -1;
                ClassWindow _ClassWindow = new ClassWindow();
             //   _ClassWindow.Owner = this;
                _ClassWindow.ShowDialog();
                if (_ClassWindow.DialogResult == true)
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
            ClassWindow _ClassWindow = new ClassWindow();
            //   _ClassWindow.Owner = this;
            if(_Class_List.SelectedIndex != -1)
            _ClassWindow.ShowDialog();
            if (_ClassWindow.DialogResult == true)
            {
                Classes[_Class_List.SelectedIndex] = _ClassWindow.MainClassObject;
                //Dalej wpisac na liste
            }
            _Class_List.Items.Refresh();
            Preview_TextBox.Text = Classes[_Class_List.SelectedIndex].ToFinalString();
        }

        private void _Class_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_Class_List.SelectedIndex != -1)
            Preview_TextBox.Text = Classes[_Class_List.SelectedIndex].ToFinalString();
        }

        private void CopyTo_Clipboard_Click(object sender, RoutedEventArgs e)
        {
            string textforClipboard = Preview_TextBox.Text.Replace("\n", Environment.NewLine);
            Clipboard.Clear();
            Clipboard.SetText(textforClipboard);
        }

        private void CopyTo_File_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Title = "Save as";
            if (_Class_List.SelectedItem != null)
                saveFileDialog.FileName = Classes[_Class_List.SelectedIndex].Name;
            else
                saveFileDialog.FileName = "Your_Class";
            if (saveFileDialog.ShowDialog() == true)
            {
                string textforClipboard = Preview_TextBox.Text.Replace("\n", Environment.NewLine);
                File.WriteAllText(saveFileDialog.FileName, textforClipboard);
            }
        }

        private void Exodia_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Up_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_Class_List.SelectedIndex > 0)
                _Class_List.SelectedIndex--;
            else
                _Class_List.SelectedIndex = 0;
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_Class_List.SelectedIndex < 0)
                _Class_List.SelectedIndex = 0;
            else
                _Class_List.SelectedIndex++;
        }
    }
}
