using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider customerDataProvider;
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();
        
        private CustomerItemViewModel? selectedCustomer;
        public CustomerItemViewModel? SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                this.selectedCustomer = value;
                this.NotifyPropertyChanged();
                this.DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private NavigationSide navigationSide;

        public NavigationSide NavigationSide
        {
            get
            {
                return this.navigationSide;
            }

            set
            {
                this.navigationSide = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this.customerDataProvider = customerDataProvider;
            this.AddCommand = new DelegateCommand(this.Add);
            this.MoveNavigationCommand = new DelegateCommand(this.MoveNavigation);
            this.DeleteCommand = new DelegateCommand(this.Delete, this.CanDelete);
        }

        public async Task LoadAsync()
        {
            if (this.Customers.Any())
            {
                return;
            }

            var customers = await this.customerDataProvider.GetAllAsync();

            if (customers != null)
            {
                foreach (Customer customer in customers)
                {
                    this.Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        private void Add(object? parameterk)
        {
            var customer = new Customer
            {
                FirstName = "New"
            };

            CustomerItemViewModel customerItemViewModel = new CustomerItemViewModel(customer);
            this.Customers.Add(customerItemViewModel);
            this.SelectedCustomer = customerItemViewModel;
        }

        private void MoveNavigation(object? parameter)
        {
            if (this.NavigationSide == NavigationSide.Left)
            {
                this.NavigationSide = NavigationSide.Right;
            }
            else
            {
                this.NavigationSide = NavigationSide.Left;
            }
        }

        private void Delete(object? parameter)
        {
            if (this.SelectedCustomer != null)
            {
                this.Customers.Remove(this.SelectedCustomer);
                this.SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter)
        {
            return this.SelectedCustomer != null;
        }
    }

    public enum NavigationSide
    {
        Left,
        Right
    }
}
