using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Concrete;
using SportStoreDomainLibrary.Entities;
using SportStoreDomainLibrary.DataContext;

namespace BasicSportStoreWpfApp.Products
{
    /// <summary>
    /// Interaction logic for ProductEditDatabindView.xaml
    /// </summary>
    public partial class ProductEditDatabindView : UserControl
    {
        iProductRepository _productRepostory;
        Product _products;
        public ProductEditDatabindView()
        {
            _productRepostory = new EFProductRepository();
            InitializeComponent();
        }

        public int ProductId
        {
            get { return (int)GetValue(ProductIdProperty); }
            set { SetValue(ProductIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductIdProperty =
            DependencyProperty.Register("ProductId", typeof(int), typeof(ProductEditDatabindView), new PropertyMetadata(0));

        async void Onloaded(object sender, RoutedEventArgs e)
        {
            _products = await _productRepostory.GetProductAsync(ProductId);
            this.DataContext = _products;

        }

        public async void save(object sender, RoutedEventArgs e)
        {
            var result = await _productRepostory.UpdateProductAsync(_products);
            if (result != null)
            {
                MessageBox.Show("Product Updated..");
            }
        }

    }
}
