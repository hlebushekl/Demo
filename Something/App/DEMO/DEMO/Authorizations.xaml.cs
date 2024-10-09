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
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Authorization.Log(tb_Log.Text, pb_Pass.Password))
            {
                switch (Authorization.role(tb_Log.Text))
                {
                    case "Администратор":
                        MessageBox.Show("Добро пожаловать" + Authorization.Name(tb_Log.Text));
                        break;

                    case "Менеджер":
                        MessageBox.Show("Добро пожаловать" + Authorization.Name(tb_Log.Text));
                        break;

                    case "Кадры":
                        MessageBox.Show("Добро пожаловать" + Authorization.Name(tb_Log.Text));
                        break;

                    case "Партнёр":
                        MessageBox.Show("Добро пожаловать" + Authorization.Name(tb_Log.Text));
                        break;

                    default:
                        break;
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный");
        }

        private void Border_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Registration kl = new Registration();
            kl.Show();
            this.Close();
        }
    }
}
