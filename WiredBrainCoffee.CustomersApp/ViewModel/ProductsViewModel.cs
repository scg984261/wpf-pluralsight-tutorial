using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductDataProvider productDataProvider;
        public ObservableCollection<Product> Products { get; }

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            this.productDataProvider = productDataProvider;
            this.Products = new ObservableCollection<Product>();
        }

        public override async Task LoadAsync()
        {
            if (this.Products.Any())
            {
                return;
            }

            var products = await productDataProvider.GetAllAsync();

            if (products != null)
            {
                foreach (var product in products)
                {
                    this.Products.Add(product);
                }
            }
        }
    }
}
