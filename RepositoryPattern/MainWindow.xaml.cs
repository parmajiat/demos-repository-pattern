using RepositoryPattern.Data;
using RepositoryPattern.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RepositoryPattern
{
    public partial class MainWindow : Window
    {
        IDataRepository repo;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datasourceList.SelectedIndex = 0;
        }

        private void DatasourceChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = datasourceList.SelectedIndex;
            if (index == 0)
            {
                DependencyInjection.Option = "Memory";
            }
            else if (index == 1)
            {
                DependencyInjection.Option = "SQL";
            }
            repo = DependencyInjection.GetInstance();
            GetData();
        }

        private async void GetData()
        {
            busyIndicator.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = await repo.GetEmployees();
            busyIndicator.Visibility = Visibility.Collapsed;
        }

        private void NewEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeView view = new EmployeeView(new Models.Employee());
            view.ShowDialog();
            GetData();
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee model = (Employee)dataGrid.SelectedItem;
                EmployeeView view = new EmployeeView(model);
                view.ShowDialog();
            }
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee model = (Employee)dataGrid.SelectedItem;
                MessageBox.Show("Deleted" + model.Name);
            }
        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Repository Pattern by Parmajiat Foundation 2020", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
