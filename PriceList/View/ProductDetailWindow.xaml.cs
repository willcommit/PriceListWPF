using PriceList.Classes;
using SQLite;
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
using System.Windows.Shapes;

namespace PriceList
{
    /// <summary>
    /// Interaction logic for NewPartsWindows.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        Product product;
        public ProductDetailWindow(Product product)
        {
            InitializeComponent();

            this.product = product;

            ItemNoTextBox.Text = product.ItemNo;
            ModelTextBox.Text = product.Model;
            DescriptionTextBox.Text = product.Description;
            CostTextBox.Text = product.UnitCost.ToString();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            product.ItemNo = ItemNoTextBox.Text;
            product.Model = ModelTextBox.Text;
            product.Description = DescriptionTextBox.Text;
            product.UnitCost = Int32.Parse(CostTextBox.Text);

            using (SQLiteConnection connection = new SQLiteConnection(ProductDB.databasePath))
            {
                connection.Update(product);
            }

            Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ProductDB.databasePath))
            {
                connection.Delete(product);
            }

            Close();
        }

        private void ItemCodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
