using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel customerViewModel;

        public CustomersView()
        {
            InitializeComponent();
            this.customerViewModel = new CustomersViewModel(new CustomerDataProvider());
            this.DataContext = this.customerViewModel;
            this.Loaded += this.CustomersView_Loaded;
        }

        public async void CustomersView_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            await customerViewModel.LoadAsync();
        }

        public void ButtonMoveNavigation_Click(object sender, RoutedEventArgs eventArgs)
        {
            int column = Grid.GetColumn(this.customerListGrid);

            int newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, newColumn);
        }
    }
}
