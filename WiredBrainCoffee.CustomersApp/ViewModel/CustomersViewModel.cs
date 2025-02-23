using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;
using System;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel
    {
        private readonly ICustomerDataProvider customerDataProvider;
        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();
        public Customer? SelectedCustomer { get; set; }

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
                    this.Customers.Add(customer);
                }
            }
        }

        public void Add()
        {
            var customer = new Customer
            {
                FirstName = "New"
            };

            this.Customers.Add(customer);
            this.SelectedCustomer = customer;
        }
    }
}
