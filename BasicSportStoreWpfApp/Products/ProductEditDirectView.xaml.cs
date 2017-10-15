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
    /// Interaction logic for ProductEditDirectView.xaml
    /// </summary>
    public partial class ProductEditDirectView : UserControl
    {
        iProductRepository _productRepostory;
        Product _products;
        public ProductEditDirectView()
        {
            _productRepostory = new EFProductRepository();
            InitializeComponent();
        }



        public int ProductId
        {
            get { return (int)GetValue(ProductIdProperty); }
            set { SetValue(ProductIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductIdProperty =
            DependencyProperty.Register("ProductId", typeof(int), typeof(ProductEditDirectView), new PropertyMetadata(0));

        async void Onloaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            _products = await _productRepostory.GetProductAsync(ProductId);
            if (_products != null)
            {
                txtProductname.Text = _products.ProductName;
                txtDiscription.Text = _products.Description;
                txtPrice.Text = _products.Price.ToString();
                txtCategory.Text = _products.Category;
            }

        }

        public async void save(object sender, RoutedEventArgs e)
        {
            _products.ProductName = txtProductname.Text;
            _products.Description = txtDiscription.Text;
            _products.Category = txtCategory.Text;
            _products.Price = Convert.ToDecimal(txtPrice.Text);
            var result = await _productRepostory.UpdateProductAsync(_products);
            if (result!=null)
            {
                MessageBox.Show("Product Updated..");
            }
        }
    }
}
