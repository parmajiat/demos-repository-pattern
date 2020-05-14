using RepositoryPattern.Data;
using RepositoryPattern.Models;
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

namespace RepositoryPattern
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        IDataRepository repo = DependencyInjection.GetInstance();
        Employee employee;
        public EmployeeView(Employee model)
        {
            InitializeComponent();
            employee = model;
            DataContext = employee;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            repo.SaveEmployee(employee);
            Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
