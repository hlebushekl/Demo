using System.Windows;
using System.Windows.Input;

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Registrations.RegistrResult(tb_Log.Text, tb_Pass.Text, tb_Nomer.Text, tb_Mail.Text, tb_Name.Text))
            {
                MessageBox.Show("Регистрация прошла успешно");
                Authorizations win = new Authorizations();
                win.Show();
                this.Close();
            }
            else
                MessageBox.Show("Данные введены неверно");
        }
    }
}
