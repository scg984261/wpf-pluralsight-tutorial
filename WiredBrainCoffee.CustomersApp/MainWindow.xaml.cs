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
            int column = (int) this.customerListGrid.GetValue(Grid.ColumnProperty);

            int newColumn = column == 0 ? 2 : 0;

            this.customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
        }
    }
}
