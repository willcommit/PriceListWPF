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
    public partial class NewPartsWindow : Window
    {
        public NewPartsWindow()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SparePart sparePart = new SparePart()
            {
                ItemCode = ItemCodeTextBox.Text,
                Description = DescriptionTextbBox.Text,
                Type = TypeTextBox.Text,
                FCAPrice = FCAPriceTextBox.Text
            };

            

            using (SQLiteConnection connection = new SQLiteConnection(SparePartDB.databasePath))
            {
                connection.Insert(sparePart);
            }

            Close();
        }
    }
}
