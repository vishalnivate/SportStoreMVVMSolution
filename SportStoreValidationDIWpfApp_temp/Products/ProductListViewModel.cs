using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;
using SportStoreValidationDIWpfApp;

namespace SportsStoreValidationDIWpfApp.Products
{
  class ProductListViewModel: BindableBase
  {
    private IProductRepository _productRepository;
    private ObservableCollection<Product> _products;
    private List<Product> _allProducts;

    public ObservableCollection<Product> Products
    {
      get => _products;
      set => SetProperty(ref _products, value);
    }

    public RelayCommand<Product> EditProductCommand { get; set; }
    public event Action<Product> EditProductRequested = delegate { };
    public RelayCommand<Product> DeleteProductCommand { get; set; }


    public ProductListViewModel(IProductRepository productRepository)
    {
      _productRepository = productRepository;

      EditProductCommand = new RelayCommand<Product>(OnEditProduct);
      DeleteProductCommand = new RelayCommand<Product>(OnDeleteProduct);
    }

    private void OnDeleteProduct(Product product)
    {
      Products.Remove(product);
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
      _allProducts = _productRepository.GetProductsAsync().Result;
    }
  }
}
