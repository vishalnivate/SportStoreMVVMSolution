using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Entities;
namespace SportStoreValidationDIWpfApp.Products
{
    public class ProductListViewModel : BindableBase
    {
        private iProductRepository _productRepository;
        private ObservableCollection<Product> _products;
        private List<Product> _allProducts;

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }

            set
            {
                SetProperty(ref _products, value);
            }
        }

        public ProductListViewModel(iProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void LoadProduct()
        {
            GetAllProducts();
            GetProducts();
        }

        private void GetAllProducts()
        {
            _allProducts = _productRepository.GetProductAsync().Result;
        }

        private void GetProducts()
        {
            Products = new ObservableCollection<Product>(_allProducts);
        }
    }
}
