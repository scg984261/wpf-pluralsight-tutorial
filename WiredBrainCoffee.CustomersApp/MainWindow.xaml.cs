using System.Windows;
using System.Windows.Controls;

namespace WiredBrainCoffee.CustomersApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonMoveNavigation_Click(object sender, RoutedEventArgs eventArgs)
        {
            int column = Grid.GetColumn(this.customerListGrid);

            int newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, newColumn);
        }
    }
}
