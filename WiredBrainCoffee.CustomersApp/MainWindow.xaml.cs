using System.Windows;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainViewModel(new CustomersViewModel(new CustomerDataProvider()), new ProductsViewModel());
            this.DataContext = this.viewModel;
            this.Loaded += this.MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs args)
        {
            await this.viewModel.LoadAsync();
        }
    }
}
