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
using System.Windows.Markup;
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
            if (_Class_List.SelectedIndex != -1)
            {
                Classes.RemoveAt(_Class_List.SelectedIndex);
            }
            _Class_List.Items.Refresh();
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            ClassWindow _ClassWindow = new ClassWindow();
            //   _ClassWindow.Owner = this;
            if (_Class_List.SelectedIndex != -1)
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
            if (_Class_List.SelectedIndex != -1)
                Preview_TextBox.Text = Classes[_Class_List.SelectedIndex].ToFinalString();
        }

        
        private void PrintCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_Class_List.SelectedIndex == -1)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            TextBlock Class_Text = new TextBlock();
            Class_Text.Measure(new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));
            Class_Text.Arrange(new Rect(new Point(50,50),new Point(printDialog.PrintableAreaWidth, printDialog.PrintableAreaWidth)));
            Class_Text.Text = Preview_TextBox.Text.Replace("\n", Environment.NewLine);
            if (printDialog.ShowDialog().GetValueOrDefault())
            {
                printDialog.PrintVisual(Class_Text, "Printing Class");

            }
        }
        private void CopyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_Class_List.SelectedIndex == -1)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void CopyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            string textforClipboard = Preview_TextBox.Text.Replace("\n", Environment.NewLine);
            Clipboard.Clear();
            Clipboard.SetText(textforClipboard);
        }
        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_Class_List.SelectedIndex == -1)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
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

    public static class OutputCommand
    {
        public static readonly RoutedUICommand Print = new RoutedUICommand
        (
            "Print",
            "Print",
            typeof(OutputCommand)
        );
        public static RoutedUICommand Print_Init
        {
            get
            {
                return Print;
            }
        }
        public static readonly RoutedUICommand Copy = new RoutedUICommand
        (
            "Copy",
            "Copy",
            typeof(OutputCommand)
        );
        public static RoutedUICommand Copy_Init
        {
            get
            {
                return Copy;
            }
        }
        public static readonly RoutedUICommand Save = new RoutedUICommand
        (
            "Save",
            "Save",
            typeof(OutputCommand)
        );
        public static RoutedUICommand Save_Init
        {
            get
            {
                return Save;
            }
        }

    }
    public static class Arrow
    {
        public static readonly RoutedUICommand Up = new RoutedUICommand
        (
            "Up",
            "Up",
            typeof(Arrow)
        );
        public static RoutedUICommand GoUp
        {
            get
            {
                return Up;
            }
        }
        public static readonly RoutedUICommand Down = new RoutedUICommand
        (
            "Down",
            "Down",
            typeof(Arrow)
        );
        public static RoutedUICommand GoDown
        {
            get
            {
                return Down;
            }
        }
    }
}
