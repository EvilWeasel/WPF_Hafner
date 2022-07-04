using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace RechenTaschen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Operation Current_Operation { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeOp(object sender, RoutedEventArgs e)
        {
            btn_add.Background = null;
            btn_sub.Background = null;
            btn_mul.Background = null;
            btn_div.Background = null;
            // Debug.WriteLine(sender.ToString().Substring(sender.ToString().Length-3));
            switch ((sender as Button).Content)
            {
                case "Add":
                    Current_Operation = Operation.Add;
                    btn_add.Background = Brushes.LightBlue;
                    break;
                case "Sub":
                    Current_Operation = Operation.Sub;
                    btn_sub.Background = Brushes.LightBlue;
                    break;
                case "Mul":
                    Current_Operation = Operation.Mul;
                    btn_mul.Background = Brushes.LightBlue;
                    break;
                case "Div":
                    Current_Operation = Operation.Div;
                    btn_div.Background = Brushes.LightBlue;
                    break;
            }
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            decimal num1 = CastStrToDec(txb_num1.Text);
            decimal num2 = CastStrToDec(txb_num2.Text);
            switch (Current_Operation)
            {
                case Operation.Add:
                    txb_result.Text = (num1 + num2).ToString();
                    break;
                case Operation.Sub:
                    txb_result.Text = (num1 - num2).ToString();
                    break;
                case Operation.Mul:
                    txb_result.Text = (num1 * num2).ToString();
                    break;
                case Operation.Div:
                    if (num2 == 0)
                    {
                        MessageBox.Show("Warning: Don't divide by zero!!!");
                        break;
                    }
                    txb_result.Text = (num1 / num2).ToString();
                    break;
            }
            if (txb_result.TextAlignment == TextAlignment.Center) txb_result.TextAlignment = TextAlignment.Right;
        }

        private decimal CastStrToDec(string text)
        {
            decimal res = 0;
            bool ok = decimal.TryParse(text, out res);
            if (!ok) return 0;
            else return res;
        }
    }
    public enum Operation
    {
        Add,
        Sub,
        Mul,
        Div
    }
}
