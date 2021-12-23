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
using WPF.LZW;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для LZW_Window.xaml
    /// </summary>
    public partial class LZW_Window : Window
    {
        LZW_Controller lzw = new LZW_Controller();

        public LZW_Window()
        {
            InitializeComponent();
            t1.Visibility = Visibility.Hidden;
            t2.Visibility = Visibility.Hidden;
        }

        private void CreateString(LZW_Coding_String data)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;

            TextBox currentString = new TextBox();
            currentString.Text = data.CurrentString;
            currentString.Width = 80;
            currentString.TextAlignment = TextAlignment.Center;
            TextBox currentSymbol = new TextBox();
            currentSymbol.Text = data.CurrentSymbol.ToString();
            currentSymbol.Width = 90;
            currentSymbol.TextAlignment = TextAlignment.Center;
            TextBox nextSymbol = new TextBox();
            nextSymbol.Text = data.NextSymbol.ToString();
            nextSymbol.Width = 70;
            nextSymbol.TextAlignment = TextAlignment.Center;
            TextBox code = new TextBox();
            code.Text = data.Code.ToString();
            code.Width = 35;
            code.TextAlignment = TextAlignment.Center;
            TextBox bits = new TextBox();
            bits.Width = 50;
            bits.TextAlignment = TextAlignment.Center;
            bits.Text = data.Bytes;
            TextBox dictionary = new TextBox();
            dictionary.Width = 70;
            dictionary.TextAlignment = TextAlignment.Center;
            dictionary.Text = data.Dictionary;

            wp.Children.Add(currentString);
            wp.Children.Add(currentSymbol);
            wp.Children.Add(nextSymbol);
            wp.Children.Add(code);
            wp.Children.Add(bits);
            wp.Children.Add(dictionary);

            compressContainer.Children.Add(wp);
        }

        private void CreateString(LZW_Decoding_String data)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;

            TextBox Bits = new TextBox();
            Bits.Text = data.Bytes;
            Bits.Width = 90;
            Bits.TextAlignment = TextAlignment.Center;
            TextBox code = new TextBox();
            code.Text = data.Code.ToString();
            code.Width = 60;
            code.TextAlignment = TextAlignment.Center;
            TextBox onExit = new TextBox();
            onExit.Text = data.OnExit.ToString();
            onExit.Width = 70;
            onExit.TextAlignment = TextAlignment.Center;
            TextBox FullNote = new TextBox();
            FullNote.Text = data.FullNewNote;
            FullNote.Width = 80;
            FullNote.TextAlignment = TextAlignment.Center;
            TextBox PartialNote = new TextBox();
            PartialNote.Width = 80;
            PartialNote.TextAlignment = TextAlignment.Center;
            PartialNote.Text = data.PartNewNote;

            wp.Children.Add(Bits);
            wp.Children.Add(code);
            wp.Children.Add(onExit);
            wp.Children.Add(FullNote);
            wp.Children.Add(PartialNote);

            decompressContainer.Children.Add(wp);

            outputTB.Text += data.OnExit;
        }

        private void StartCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            lzw.InitCompress(sourceTB.Text);
            iterationCmprBtn.IsEnabled = true;
            allCmprBtn.IsEnabled = true;
            startCmprBtn.IsEnabled = false;
        }

        private void IterationCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateString(lzw.GetCodingString());

            if (lzw.IsCompressionEnd)
            {
                iterationCmprBtn.IsEnabled = false;
                allCmprBtn.IsEnabled = false;
                startDecmprBtn.IsEnabled = true;
            }
        }

        private void AllCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            var time1 = DateTime.Now;
            foreach (var str in lzw.GetRemainingCodingStrings())
            {
                CreateString(str);
            }

            iterationCmprBtn.IsEnabled = false;
            allCmprBtn.IsEnabled = false;
            startDecmprBtn.IsEnabled = true;
            var time2 = DateTime.Now;
            t1.Visibility = Visibility.Visible;
            timeC.Text = ((sourceTB.Text.Length * 8) / (time2 - time1).TotalSeconds).ToString("#.##") + " bit/s";
        }

        private void StartDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            lzw.InitDecompress();

            startDecmprBtn.IsEnabled = false;
            iterationDecmprBtn.IsEnabled = true;
            allDecmprBtn.IsEnabled = true;
        }

        private void IterationDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateString(lzw.GetDecodingString());

            if (lzw.IsDecompressionEnd)
            {
                iterationDecmprBtn.IsEnabled = false;
                allDecmprBtn.IsEnabled = false;
            }
        }

        private void AllDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            var time1 = DateTime.Now;
            foreach (var str in lzw.GetRemainingDecodingStrings())
            {
                CreateString(str);
            }

            iterationDecmprBtn.IsEnabled = false;
            allDecmprBtn.IsEnabled = false;
            var time2 = DateTime.Now;
            
        }
    }
}
