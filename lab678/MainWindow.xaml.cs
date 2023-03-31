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
        private List<double> masReal=new List<double>();
        private Queue<double> queueReal=new Queue<double>();
        private NodeStack<Monitor> stack=new NodeStack<Monitor> ();
        private OurQueue<double> doubleQeeue=new OurQueue<double> ();
        private OurList<int> intList=new OurList<int> ();
        public MainWindow()
        {
            InitializeComponent();
           // lbLab8.ItemsSource = intList;
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tbMas.Text = "";
            try
            {
                int n = int.Parse(txtSize.Text);
                for (int i = 0; i < n; i++)
                {
                    Random rnd=new Random();
                    double temp = rnd.NextDouble()*100-50;
                    masReal.Add(temp);
                    tbMas.Text += temp.ToString("F2") + " ";
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (var item in masReal)
            {
                if(item>-15&&item<4) count++;
            }
            lbResult.Text ="Количество элементов промежутка (-15,4):"+count.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            masReal.Clear();
            lbResult.Text = "";
            tbMas.Text = "";
            txtSize.Clear();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            double n=double.Parse(txtInputReal.Text);
            queueReal.Enqueue(n);
            lbQueqe.Items.Add(n.ToString());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (var item in queueReal)
            {
                if (item < 0) count++;
            }
            QueqeResult.Text= count.ToString(); 
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Monitor monitor = new Monitor(nameMonitor.Text, int.Parse(diagonalMonitor.Text),
                int.Parse(priceMonitor.Text));
            stack.Push(monitor);
            TreeViewItem item = new TreeViewItem();
            item.Tag ="Запись "+stack.Count;
            item.Header = "Запись " + stack.Count;
            item.Items.Add(monitor.Name);
            item.Items.Add(monitor.Diagonal);
            item.Items.Add(monitor.Price);
            treeList.Items.Add(item);
            nameMonitor.Clear();
            diagonalMonitor.Clear();
            priceMonitor.Clear();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            double n = double.Parse(txtQueqeEnter.Text);
            doubleQeeue.Enqueue(n);
            Perebor();
            txtQueqeEnter.Clear();
        }
        void Perebor()
        {
            lbQueueReal.Items.Clear();
            foreach (double item in doubleQeeue)
            {
                lbQueueReal.Items.Add(item);
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {   
            doubleQeeue.Dequeue();
            Perebor();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            double P = 1;
            foreach (double item in doubleQeeue)
            {
                if (item > 0) P *= item;
            }
            txbCountPositive.Text = "Произведение положительных " + P;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            int n=int.Parse(txtLab8.Text);
            intList.Add(n);
            UpdateIntList();
            txtLab8.Clear();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            int index = -1;
            int i = 0;
            foreach (int item in intList)
            {
                if (item > 10)
                {
                    index = i;
                    break;
                }
                i++;
            }
            intList.Insert(12, index);
            UpdateIntList();
        }
        private void UpdateIntList()
        {
            lbLab8.Items.Clear();
            foreach (int item in intList)
            {
                lbLab8.Items.Add(item);
            }
            //lbLab8.Items.Refresh();
        }
    }
}
