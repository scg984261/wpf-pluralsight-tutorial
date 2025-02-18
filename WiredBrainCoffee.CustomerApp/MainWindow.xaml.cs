using System.Windows;

namespace WiredBrainCoffee.CustomerApp
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

        private void NewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Customer Added!");
        }
    }
}