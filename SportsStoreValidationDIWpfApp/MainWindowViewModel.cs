using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using SportStoreValidationDIWpfApp.Products;
using SportStoreDomainLibrary.Entities;

namespace SportStoreValidationDIWpfApp
{
    class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;
        private ProductListViewModel _productListViewModel;
        private AddEditProductViewModel _addEditProductViewModel;



        public RelayCommand<string> NavigateCommand { get; private set; }
        public RelayCommand AddNewProductCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public MainWindowViewModel()
        {
            _productListViewModel = SportsStoreContainer.Container.Resolve<ProductListViewModel>();
            _productListViewModel.EditProductRequested += NavigateToEditProduct;


            _addEditProductViewModel = SportsStoreContainer.Container.Resolve<AddEditProductViewModel>();
            _addEditProductViewModel.CancelCommandRequested += OnNavigate;
            _addEditProductViewModel.SaveCommandRequested += OnNavigate;


            NavigateCommand = new RelayCommand<string>(OnNavigate);
            AddNewProductCommand = new RelayCommand(OnAddNewProduct);
        }

        private void NavigateToEditProduct(Product product)
        {
            _addEditProductViewModel.EditFlag = true;
            _addEditProductViewModel.SetProduct(product);
            CurrentViewModel = _addEditProductViewModel;
        }

        private void OnAddNewProduct()
        {
            _addEditProductViewModel.EditFlag = false;
            _addEditProductViewModel.SetProduct(new Product());
            CurrentViewModel = _addEditProductViewModel;
        }

        private void OnNavigate(string destination)
        {
            switch (destination)
            {
                case "addNewProduct":
                    _addEditProductViewModel.EditFlag = false;
                    _addEditProductViewModel.SetProduct(new Product());
                    CurrentViewModel = _addEditProductViewModel;
                    break;
                default:
                    CurrentViewModel = _productListViewModel;
                    break;
            }
        }
    }
}
