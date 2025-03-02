using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public CustomersViewModel CustomersViewModel { get;  }
        public ProductsViewModel ProductsViewModel { get;  }
        private ViewModelBase? selectedViewModel;
        public DelegateCommand SelectViewModelCommand { get; }

        public ViewModelBase? SelectedViewModel
        {
            get
            {
                return this.selectedViewModel;
            }

            set
            {
                this.selectedViewModel = value;
                this.NotifyPropertyChanged();
            }
        }

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            this.CustomersViewModel = customersViewModel;
            this.ProductsViewModel = productsViewModel;
            this.SelectedViewModel = this.CustomersViewModel;
            this.SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await this.SelectedViewModel.LoadAsync();
            }
        }

        public async void SelectViewModel(object? parameter)
        {
            this.SelectedViewModel = parameter as ViewModelBase;
            await this.LoadAsync();
        }
    }
}
