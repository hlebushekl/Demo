using System.Windows;
using System.Windows.Input;

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorizations : Window
    {
        public Authorizations()
        {
            InitializeComponent();
            move.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Authorization.Log(tb_Log.Text, pb_Pass.Password))
            {
                string name = Authorization.Name(tb_Log.Text);
                MessageBox.Show("Добро пожаловать " + name);
                Admina kl = new Admina();
                kl.Show();
                this.Close();
            }
            else if (tb_Log.Text == null || pb_Pass.Password == null)
                MessageBox.Show("Поля пустые");           
            else
            {
                pb_Pass.Password = null;
                MessageBox.Show("Логин или пароль неверный");
            }
        }

        private void Border_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Registration kl = new Registration();
            kl.Show();
            this.Close();
        }
    }
}
