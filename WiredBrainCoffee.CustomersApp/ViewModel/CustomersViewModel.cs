using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

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
            }
        }

        private int navigationColumn;

        public int NavigationColumn
        {
            get
            {
                return this.navigationColumn;
            }

            set
            {
                this.navigationColumn = value;
                NotifyPropertyChanged();
            }
        }


        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this.customerDataProvider = customerDataProvider;
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

        internal void Add()
        {
            var customer = new Customer
            {
                FirstName = "New"
            };

            CustomerItemViewModel customerItemViewModel = new CustomerItemViewModel(customer);
            this.Customers.Add(customerItemViewModel);
            this.SelectedCustomer = customerItemViewModel;
        }

        internal void MoveNavigation()
        {
            int newColumn = this.NavigationColumn == 0 ? 2 : 0;
            this.NavigationColumn = newColumn;
        }
    }
}
