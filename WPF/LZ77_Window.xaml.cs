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
using WPF.LZ77;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для LZ77_Window.xaml
    /// </summary>
    public partial class LZ77_Window : Window
    {
        public LZ77_Window()
        {
            InitializeComponent();
            t1.Visibility = Visibility.Hidden;
            t2.Visibility = Visibility.Hidden;

        }

        LZ77_Controller controller = new LZ77_Controller();

        private void CreateString(LZ77_Node data)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;
            
            TextBox dictionary = new TextBox();
            dictionary.Text = data.Buffer;
            dictionary.Width = 130;
            dictionary.TextAlignment = TextAlignment.Center;
            //TextBox remainingMessage = new TextBox();
            //remainingMessage.Text = data.FoundPrefix;
            //remainingMessage.Width = 130;
            //remainingMessage.TextAlignment = TextAlignment.Center;
            TextBox Prefix = new TextBox();
            Prefix.Text = string.Format("<{0}, {1}>", data.Offset, /*data.Length,*/ data.Next);
            Prefix.Width = 60;
            Prefix.TextAlignment = TextAlignment.Center;

            wp.Children.Add(dictionary);
            //wp.Children.Add(remainingMessage);
            wp.Children.Add(Prefix);

            compressContainer.Children.Add(wp);
        }

        private void CreateDecodingString(LZ77_Decoder_String data)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Horizontal;

            TextBox dictionary = new TextBox();
            dictionary.Text = string.Format("<{0}, {1}, {2}>", data.Node.Offset, data.Node.Length, data.Node.Next);
            dictionary.Width = 120;
            dictionary.TextAlignment = TextAlignment.Center;
            TextBox remainingMessage = new TextBox();
            remainingMessage.Text = data.Answer.ToString();
            remainingMessage.Width = 120;
            remainingMessage.TextAlignment = TextAlignment.Center;

            wp.Children.Add(dictionary);
            wp.Children.Add(remainingMessage);

            decompressContainer.Children.Add(wp);

            outputTB.Text = data.Answer;
        }

        private void StartCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            int bufSize;
            if (!Int32.TryParse(bufferSizeTB.Text, out bufSize))
            {
                bufSize = 10;
            }
            controller.InitCompress(sourceTB.Text, bufSize);
            iterationCmprBtn.IsEnabled = true;
            allCmprBtn.IsEnabled = true;
            startCmprBtn.IsEnabled = false;
        }

        private void IterationCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateString(controller.GetCodingString());

            if (controller.IsCompressionEnd)
            {
                iterationCmprBtn.IsEnabled = false;
                allCmprBtn.IsEnabled = false;
                startDecmprBtn.IsEnabled = true;
            }
        }

        private void AllCmprBtn_Click(object sender, RoutedEventArgs e)
        {
            var time1 = DateTime.Now;
            foreach (var str in controller.GetRemainingCodingStrings())
            {
                CreateString(str);
            }

            iterationCmprBtn.IsEnabled = false;
            allCmprBtn.IsEnabled = false;
            startDecmprBtn.IsEnabled = true;
            var time2 = DateTime.Now;
            t1.Visibility = Visibility.Visible;
            timeC.Text = ((sourceTB.Text.Length*8)/ (time2 - time1).TotalSeconds).ToString("#.##") + " bit/s";
        }

        private void StartDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.InitDecompress();

            startDecmprBtn.IsEnabled = false;
            iterationDecmprBtn.IsEnabled = true;
            allDecmprBtn.IsEnabled = true;
        }

        private void IterationDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateDecodingString(controller.GetDecodingString());

            if (controller.IsDecompressionEnd)
            {
                iterationDecmprBtn.IsEnabled = false;
                allDecmprBtn.IsEnabled = false;
            }
        }

        private void AllDecmprBtn_Click(object sender, RoutedEventArgs e)
        {
            var time1 = DateTime.Now;
            foreach (var str in controller.GetRemainingDecodingStrings())
            {
                CreateDecodingString(str);
            }

            iterationDecmprBtn.IsEnabled = false;
            allDecmprBtn.IsEnabled = false;
            var time2 = DateTime.Now;
            
        }
    }
}
