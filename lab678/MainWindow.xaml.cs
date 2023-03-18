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

namespace lab678
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> mas=new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtInterMass.Text.Length != 0)
            {
                string str = txtInterMass.Text;
                if (str[str.Length-1]==',') str=str.Substring(0,str.Length-1);
                string[] strmas = str.Split(',');
                string res = "";
                foreach (var item in strmas)
                {
                    mas.Add(int.Parse(item));
                    res += item + " ";
                }
                tbMassive.Text = res;
            }
            else
            {
                MessageBox.Show("Введите элементы массива", "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int P = 1;
            foreach (var item in mas)
            {
                if (item >= 2 && item < 8) P *= item;
            }
            tbResult.Text ="Прозведение элементов от [2,8) равно:"+P.ToString();
        }

        private void txtInterMass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.OemComma||
                e.Key==Key.Back||e.Key==Key.OemMinus)
                return;
            e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mas.Clear();
            txtInterMass.Clear();
            tbMassive.Text = "";
            tbResult.Text = "";
        }
    }
}
