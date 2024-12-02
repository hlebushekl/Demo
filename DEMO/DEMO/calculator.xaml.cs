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

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для calculator.xaml
    /// </summary>
    public partial class calculator : Window
    {
        public calculator()
        {
            InitializeComponent();
        }
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Kalk_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            double price = Convert.ToInt32(tb_price.Text.TrimEnd(',', '.'));
            double percent = Convert.ToInt32(tb_percent.Text.TrimEnd(',', '.'));
            double number_of = Convert.ToInt32(tb_number_of.Text.TrimEnd(',', '.'));
            double summ;
            percent = (percent / 100) * price;
            summ = (percent + price) * number_of;
            tb_summ.Text = Convert.ToString(summ);
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
