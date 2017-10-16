using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using SportStoreDomainLibrary.Entities;
using SportStoreDomainLibrary.Abstract;

namespace SportStoreValidationDIWpfApp.Products
{
    class ProductListViewModel : BindableBase
    {
        private iProductRepository _productRepository;
        private ObservableCollection<Product> _products;
        private List<Product> _allProducts;

        public RelayCommand<Product> EditProductCommand { get; set; }
        public event Action<Product> EditProductRequested = delegate { };
        public RelayCommand<Product> DeleteProductCommand { get; set; }

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

            EditProductCommand = new RelayCommand<Product>(OnEditProduct);
            DeleteProductCommand = new RelayCommand<Product>(OnDeleteProduct);
        }

        private void OnDeleteProduct(Product product)
        {
            _products.Remove(product);
        }

        private void OnEditProduct(Product product)
        {
            EditProductRequested(product);
        }

        public void LoadProducts()
        {
            GetAllProducts();
            GetProducts();
        }

        private void GetProducts()
        {
            Products = new ObservableCollection<Product>(_allProducts);
        }
        private void GetAllProducts()
        {
            _allProducts = _productRepository.GetProductAsync().Result;
        }
    }
}
