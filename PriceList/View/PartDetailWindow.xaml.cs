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
    public partial class PartDetailWindow : Window
    {
        SparePart sparePart;
        public PartDetailWindow(SparePart sparePart)
        {
            InitializeComponent();

            this.sparePart = sparePart;

            ItemCodeTextBox.Text = sparePart.ItemCode;
            DescriptionTextBox.Text = sparePart.Description;
            TypeTextBox.Text = sparePart.Type;
            FCAPriceTextBox.Text = sparePart.FCAPrice;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            sparePart.ItemCode = ItemCodeTextBox.Text;
            sparePart.Description = DescriptionTextBox.Text;
            sparePart.Type = TypeTextBox.Text;
            sparePart.FCAPrice = FCAPriceTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(SparePartDB.databasePath))
            {
                connection.Update(sparePart);
            }

            Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SparePartDB.databasePath))
            {
                connection.Delete(sparePart);
            }

            Close();
        }

        private void ItemCodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
