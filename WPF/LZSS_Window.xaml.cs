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
using WPF.LZSS;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для LZSS_Window.xaml
    /// </summary>
    public partial class LZSS_Window : Window
    {
        static char symbol = ',';
        static char symbol1 = '<';
        static char symbol2 = '>';
        string messageE;
        string messageC;
        public LZSS_Window()
        {
            InitializeComponent();
            CompressAll.IsEnabled = false;
            StartDecompress.IsEnabled = false;
            Decompress.IsEnabled = false;
            t1.Visibility = Visibility.Hidden;
            t2.Visibility = Visibility.Hidden;
        }

        private void StartCompress_Click(object sender, RoutedEventArgs e)
        {
            CompressAll.IsEnabled = true;
            StartCompress.IsEnabled = false;
        }

        private void CompressAll_Click(object sender, RoutedEventArgs e)
        {
            var time1 = DateTime.Now;
            string input = Message.Text;

            string output = "";
            string word;

            int longestword = 0;

            output += input[0];
            //Console.WriteLine("Вставляем: " + input[0]);
            CompressionMessage.Text = "Вставляем: "+ input[0].ToString()+"\n";

            int window = 1;
            bool control = false;

            for (int i = 1; i < input.Length; i += window)
            {
                window = 0;
            again:
                if (i + window < input.Length)
                {
                    window++;
                    word = input.Substring(i, window);

                    if (input.Substring(0, i).Contains(word))
                    {
                        control = true;
                        goto again;
                    }
                    else
                    {
                        if (window > 1) window--;
                    }
                }

                word = input.Substring(i, window);

                string shortcut = "" + symbol1;
                shortcut += FindInText(word, input.Substring(0, i));
                shortcut += symbol;
                shortcut += word.Length;
                shortcut += symbol2;

                bool Bshortcut = false;

                //if (word.Length > shortcut.Length)
                if (control == true)
                {
                    //place shortcut
                    Bshortcut = true;
                    output += shortcut;
                    CompressionMessage.Text += "Берем из словаря: "+shortcut+"\n";
                    if (longestword < word.Length) longestword = word.Length;
                    //Console.WriteLine("Берем из словаря: " + word);
                }
                else
                {
                    //Console.WriteLine("Вставляем: " + word);
                    output += word;
                    CompressionMessage.Text += "Вставляем: " + word + "\n";
                }
                control = false;
            }
            CompressionMessage.Text += output;
            messageE = output;
            StartDecompress.IsEnabled = true;
            CompressAll.IsEnabled = false;
            messageC = output;

            var time2 = DateTime.Now;
            t1.Visibility = Visibility.Visible;
            timeC.Text = ((Message.Text.Length * 8) / (time2 - time1).TotalSeconds).ToString("#.##") + " bit/s";
        }
        static int FindInText(string word, string text)
        {
            return text.IndexOf(word);
        }

        private void Decompress_Click(object sender, RoutedEventArgs e)
        {
            //DMessage.Text = LZSS.LZSS.DecompressLZSS(messageE);
            string output = "";

            for (int i = 0; i < messageC.Length; i++)
            {
                if (messageC[i] == symbol1)
                {
                    int startpoz = i;
                    int first, second;
                    first = 0;
                    second = 0;
                    i++;
                    try
                    {
                        do
                        {
                            first *= 10;
                            first += Int32.Parse(messageC[i].ToString());
                            i++;
                        } while (messageC[i] != symbol);

                        i++;
                        do
                        {
                            second *= 10;
                            second += Int32.Parse(messageC[i].ToString());
                            i++;
                        } while (messageC[i] != symbol2);
                        output += output.Substring(first, second);
                        DecompessionMessage.Text += "Берем из словаря: "+output.Substring(first, second) + "\n";

                    }
                    catch
                    {
                        i = startpoz;
                        output += messageC[i];
                        DecompessionMessage.Text += "Вставляем: " + messageC[i]+"\n";

                    }
                }
                else
                {
                    output += messageC[i];
                    DecompessionMessage.Text += "Вставляем: " + messageC[i] + "\n";

                }
            }
            DMessage.Text = output;
            //DecompessionMessage.Text = output;
        }

        private void StartDecompress_Click(object sender, RoutedEventArgs e)
        {
            Decompress.IsEnabled = true;
            StartDecompress.IsEnabled = false;
            
        }
    }
}
