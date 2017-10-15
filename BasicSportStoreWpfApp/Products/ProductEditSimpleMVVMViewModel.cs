using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Concrete;
using SportStoreDomainLibrary.Entities;

namespace BasicSportStoreWpfApp.Products
{
    class ProductEditSimpleMVVMViewModel : INotifyPropertyChanged
    {
        iProductRepository _productRepository;
        Product _product;

        public RelayCommand SaveCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Product"));
            }
        }

        public int ProductId { get; set; }

        public ProductEditSimpleMVVMViewModel()
        {
            _productRepository =
                new EFProductRepository();
            SaveCommand =
                new RelayCommand(OnSave);
        }

        public async void LoadProduct()
        {
            Product = await
                _productRepository.GetProductAsync(ProductId);
        }

        private async void OnSave()
        {
            Product = await
                _productRepository.UpdateProductAsync(Product);
        }
    }
}
