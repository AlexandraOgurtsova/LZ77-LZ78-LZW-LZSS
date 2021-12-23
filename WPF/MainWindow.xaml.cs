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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private byte[] archiveBytes;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UnarchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<LZ77_Window>();
        }

        private void LzwBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<LZW_Window>();
        }

        private void Lz78Btn_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<LZ78_Window>();
        }

        private void ShowWindow<T>() where T : Window, new()
        {
            var wind = new T();
            wind.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<LZSS_Window>();
        }
    }
}
