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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = null, file = null;
        string [] nameFile = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            if (Ofd.ShowDialog() == true)
            {
                path = Ofd.FileName;
                nameFile = Ofd.FileNames;
            }
            //Ofd.Filter = "Image files(*.png)|*.png| Image files(*.jpg)|*.jpg| Image files(*.jpeg)|*.jpeg";
            Console.WriteLine(path);
            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    file = sr.ReadToEnd();
                }
            }
            imageList.ItemsSource = file;
            FileName.Text = path;
        }
    }
}
