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
using System.Windows.Markup;
using System.Diagnostics;
using System.Xml;

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для Admina.xaml
    /// </summary>
    public partial class Admina : Window
    {
        public Admina()
        {
            InitializeComponent();
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Site_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://ru.investing.com/equities?ysclid=m2zunglapr417481196");
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Kalk_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            calculator calculator = new calculator();
            calculator.Show();

        }

        private void Mettal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataChenger.nameTable = "Металлы";
            Clone.Visibility = Visibility.Visible;
            string clone = XamlWriter.Save(Clone);
            Zone.Children.Clear();
            for (int i = 0; i < DataChenger.Lenght(); i++)
                Zone.Children.Add(DataChenger.Clone(clone, i));
            Clone.Visibility = Visibility.Hidden;
        }

        private void Start_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataChenger.nameTable = "Сырьё";
            Clone.Visibility = Visibility.Visible;
            string clone = XamlWriter.Save(Clone);
            Zone.Children.Clear();
            for (int i = 0; i < DataChenger.Lenght(); i++)
                Zone.Children.Add(DataChenger.Clone(clone, i));
            Clone.Visibility = Visibility.Hidden;
        }

        private void Akcii_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataChenger.nameTable = "Акции";
            Clone.Visibility = Visibility.Visible;
            string clone = XamlWriter.Save(Clone);
            Zone.Children.Clear();
            for (int i = 0; i < DataChenger.Lenght(); i++)
                Zone.Children.Add(DataChenger.Clone(clone, i));
            Clone.Visibility = Visibility.Hidden;
        }
    }
}
