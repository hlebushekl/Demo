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
                string name = Authorization.Name(tb_Log.Text);
                switch (Authorization.role(tb_Log.Text))
                {
                    case "Администратор":
                        MessageBox.Show("Добро пожаловать " + name);
                        break;

                    case "Менеджер":
                        MessageBox.Show("Добро пожаловать " + name);
                        break;

                    case "Кадры":
                        MessageBox.Show("Добро пожаловать " + name);
                        break;

                    case "Партнёр":
                        MessageBox.Show("Добро пожаловать " + name);
                        break;

                    case "Базовый":
                        MessageBox.Show("Добро пожаловать " + name);
                        break;

                    default:
                        break;
                }
            }
            else if (tb_Log.Text == null || pb_Pass.Password == null)
                MessageBox.Show("Поля пустые");
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
