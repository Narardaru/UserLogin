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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Здрасти!!! Това е твоята първа програма на Visual Studio 2012!");
        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        { 
            MessageBox.Show("This is Windows Presentation Foundation!"); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage(); 
            anotherWindow.Show();

        }
    }
}
