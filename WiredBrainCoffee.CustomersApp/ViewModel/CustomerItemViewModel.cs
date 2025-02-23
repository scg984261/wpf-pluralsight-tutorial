using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer customer;

        public CustomerItemViewModel(Customer customer)
        {
            this.customer = customer;
        }

        public string? FirstName
        {
            get
            {
                return this.customer.FirstName;
            }

            set
            {
                this.customer.FirstName = value;
                NotifyPropertyChanged();
            }
        }

        public string? LastName
        {
            get
            {
                return this.customer.LastName;
            }

            set
            {
                this.customer.LastName = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get
            {
                return this.customer.IsDeveloper;
            }

            set
            {
                this.customer.IsDeveloper = value;
                NotifyPropertyChanged();
            }
        }
    }
}
