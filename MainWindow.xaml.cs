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
using WpfApp1.Models;
using WpfApp1.ModelView;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel viewModel;
        EmployeeService emps;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
            //this.DataContext = new EmployeeViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    t1.Clear();t2.Clear();t3.Clear();
        //}
    }
}
