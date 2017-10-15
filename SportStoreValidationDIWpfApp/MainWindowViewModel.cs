using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStoreValidationDIWpfApp.Products;
using Microsoft.Practices.Unity;


namespace SportStoreValidationDIWpfApp
{
    class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;
        private ProductListViewModel _productListModel;


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

        public RelayCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel()
        {
            _productListModel = SportStoreContainer.Container.Resolve<ProductListViewModel>();
            NavigateCommand = new RelayCommand<string>(OnNavigate);
        }

        private void OnNavigate(string destination)
        {
           switch(destination)
            {
                default:
                    CurrentViewModel = _productListModel;
                    break;
            }
        }
    }
}
