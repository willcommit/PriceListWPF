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
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                ItemNo = ItemNoTextBox.Text,
                Model = ModelTextBox.Text,
                Description = DescriptionTextBox.Text,
                UnitCost = Int32.Parse(CostTextBox.Text)
            };

            using (SQLiteConnection connection = new SQLiteConnection(ProductDB.databasePath))
            {
                connection.Insert(product);
            }

            Close();
        }
    }
}
