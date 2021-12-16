using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tools_0xff
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_ToChange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Textbox_Input.Text))
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }

            if (InPut_b.IsChecked == true)
            {
                if (Output_b.IsChecked == true)
                    Textbox_Output.Text = Textbox_Input.Text;
                else if (Output_d.IsChecked == true)
                    Textbox_Output.Text = Convert.ToString(Convert.ToInt64(Textbox_Input.Text, 2));
                else if (Output_h.IsChecked == true)
                    Textbox_Output.Text = "0x" + string.Format("{0:x}", Convert.ToInt64(Textbox_Input.Text, 2));
            }
            if (Input_d.IsChecked == true)
            {
                if (Output_d.IsChecked == true)
                    Textbox_Output.Text = Textbox_Input.Text;
                else if (Output_b.IsChecked == true)
                    Textbox_Output.Text = Convert.ToString(int.Parse(Textbox_Input.Text), 2);
                else if (Output_h.IsChecked == true)
                    Textbox_Output.Text = "0x" + string.Format("{0:x}", Convert.ToInt64(Textbox_Input.Text, 10));
            }
            if (Input_h.IsChecked == true)
            {
                if (Output_h.IsChecked == true)
                    Textbox_Output.Text = "0x" + Textbox_Input.Text;
                else if (Output_b.IsChecked == true)
                    Textbox_Output.Text = Convert.ToString(int.Parse(Textbox_Input.Text,System.Globalization.NumberStyles.HexNumber), 2);
                else if (Output_d.IsChecked == true)
                    Textbox_Output.Text = Convert.ToString(int.Parse(Textbox_Input.Text,System.Globalization.NumberStyles.HexNumber),10);
            }
        }
        private void NumOnly(object sender, TextCompositionEventArgs e)
        {
            if (Input_d.IsChecked == true)
            {
                Regex re = new Regex("[^0-9]+");
                e.Handled = re.IsMatch(e.Text);
            }
            if (InPut_b.IsChecked == true)
            {
                Regex re = new Regex("[^0-1]+");
                e.Handled = re.IsMatch(e.Text);
            }
            if (Input_h.IsChecked == true)
            {
                Regex re = new Regex("[^a-f && 0-9]+");
                e.Handled = re.IsMatch(e.Text);
            }
        }

        private void Input_d_GotFocus(object sender, RoutedEventArgs e)
        {
            Textbox_Input.Text = null;
            Textbox_Output.Text = null;
        }

        private void InPut_b_GotFocus(object sender, RoutedEventArgs e)
        {
            Textbox_Input.Text = null;
            Textbox_Output.Text = null;
        }

        private void Input_h_GotFocus(object sender, RoutedEventArgs e)
        {
            Textbox_Input.Text = null;
            Textbox_Output.Text = null;
        }
    }
}
