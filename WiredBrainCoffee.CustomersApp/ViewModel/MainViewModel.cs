using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomersViewModel customersViewModel;
        private ViewModelBase? selectedViewModel;

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

        public MainViewModel(CustomersViewModel customersViewModel)
        {
            this.customersViewModel = customersViewModel;
        }

        public async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await this.SelectedViewModel.LoadAsync();
            }
        }
    }
}
