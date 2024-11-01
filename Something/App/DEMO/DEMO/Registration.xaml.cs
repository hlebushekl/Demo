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
            move.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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
