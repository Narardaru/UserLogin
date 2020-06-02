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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public static void printError(String message)
        {
            Console.WriteLine("!!! " + message + " !!!");
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginValidation lv = new LoginValidation(txtUsername.Text, txtPassword.Password, printError);

            User user = new User();

            if(lv.ValidateUserInput(ref user))
            {
                Student student = StudentValidation.GetStudentDataByUser(user);
                MainWindow mainWindow = new MainWindow();
                MainWindowVM vm = new MainWindowVM(student, mainWindow);
                mainWindow.DataContext = vm;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                resetInputFields();
            }
        }
        private void resetInputFields()
        {
            MessageBox.Show("Invalid credentials entered !");
            TextBox usernameBox = txtUsername;
            usernameBox.Clear();
            PasswordBox passwordBox = txtPassword;
            passwordBox.Clear();
        }
    }
}
