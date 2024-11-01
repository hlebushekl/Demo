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
            //string clone = XamlWriter.Save(Clone);
            //Zone.Children.Clear();
            //for (int i = 0; i < DataChenger.Lenght(); i++)
            //    Zone.Children.Add(DataChenger.Clone(clone, i));
            move.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
