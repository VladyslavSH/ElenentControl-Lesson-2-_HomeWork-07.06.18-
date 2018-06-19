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
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach(var item in Directory.GetFiles(fbd.SelectedPath))
                {
                    BitmapImage bitMap = new BitmapImage();
                    bitMap.BeginInit();
                    bitMap.UriSource = new Uri(item, UriKind.Absolute);
                    bitMap.EndInit();
                    Button button = new Button();
                    button.Click += ButtonImage_Click;
                    Image image = new Image();
                    image.Source = bitMap;
                    button.Content = image;
                    stack.Children.Add(button);
                }
            }
        }
        private void ButtonImage_Click(object sender, RoutedEventArgs e)
        {
            image.Source = ((sender as Button).Content as Image).Source;
        }
    }
}
