using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync()
        {
            return Task.CompletedTask;
        }
    }
}
