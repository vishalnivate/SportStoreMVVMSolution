using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Entities;

namespace SportsStoreValidationDIWpfApp.Products
{
  class AddEditProductViewModel : BindableBase
  {
    private IProductRepository _productRepository;
    private SimpleEditableProduct _simpleEditableProduct;
    private Product _editableProduct;
    private bool _editFlag;

    public RelayCommand SaveCommand { get; private set; }
    public event Action<string> SaveCommandRequested = delegate { };
    public RelayCommand CancelCommand { get; private set; }
    public event Action<string> CancelCommandRequested = delegate { };
    public event Action Done = delegate { };
    public AddEditProductViewModel(IProductRepository productRepository)
    {
      _productRepository = productRepository;

      CancelCommand = new RelayCommand(OnCancel);
      SaveCommand = new RelayCommand(OnSave, CanSave);
    }

    private bool CanSave()
    {
      return !SimpleEditableProduct.HasErrors;
    }

    private async void OnSave()
    {
      UpdateProduct(SimpleEditableProduct, _editableProduct);
      if (EditFlag)
      {
        await _productRepository.UpdateProductAsync(_editableProduct);
      }
      else
      {
        await _productRepository.AddProductAsync(_editableProduct);
      }
      Done();
      SaveCommandRequested("products");
    }

    private void UpdateProduct(SimpleEditableProduct source, Product target)
    {
      target.ProductName = source.ProductName;
      target.Description = source.Description;
      target.Price = source.Price;
      target.Category = source.Category;
    }

    private void OnCancel()
    {
      Done();
      CancelCommandRequested("products");
    }

    public void SetProduct(Product product)
    {
      _editableProduct = product;
      if (SimpleEditableProduct != null)
      {
        SimpleEditableProduct.ErrorsChanged -= RaiseCanExecuteChanged;
      }
      SimpleEditableProduct = new SimpleEditableProduct();
      SimpleEditableProduct.ErrorsChanged += RaiseCanExecuteChanged;
      CopyProduct(product, SimpleEditableProduct);
    }

    private void CopyProduct(Product source, SimpleEditableProduct target)
    {
      target.ProductId = source.ProductId;
      if (EditFlag)
      {
        target.ProductName = source.ProductName;
        target.Description = source.Description;
        target.Price = source.Price;
        target.Category = source.Category;
      }
    }

    private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
    {
      SaveCommand.RaiseCanExecuteChanged();
    }

    public bool EditFlag { get => _editFlag; set => SetProperty(ref _editFlag , value); }
    public SimpleEditableProduct SimpleEditableProduct { get => _simpleEditableProduct; set => SetProperty(ref _simpleEditableProduct, value); }
  }
}
