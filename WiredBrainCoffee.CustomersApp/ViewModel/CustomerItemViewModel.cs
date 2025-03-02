using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ValidationViewModelBase
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

                if (string.IsNullOrEmpty(this.customer.FirstName))
                {
                    const string errorMessage = "First name is required!";
                    this.AddError(errorMessage);
                }
                else
                {
                    this.ClearErrors();
                }
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
