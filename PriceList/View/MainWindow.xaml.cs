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
using PriceList.Classes;

namespace PriceList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SparePartDB.SetDatabasePath();
            PopulateListView();
        }

        public void PopulateListView()
        {
            SparePartDB.ReadDatabase();

            try
            {
                if (SparePartDB.parts != null)
                {
                    sparePartDataGrid.ItemsSource = SparePartDB.parts;
                    //listSizeLabel.Content = sparePartDataGrid.Items.Count;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItemImportExcel_Click(object sender, RoutedEventArgs e)
        {
            Xlxs xlxs = new Xlxs();
            xlxs.setFileName();
            var package = xlxs.readExcel();

            SparePartDB.parts.Clear();
            xlxs.populatePartsList(package, SparePartDB.parts);
            SparePartDB.PopulateDataBase();
            MessageBox.Show("COMPLETE!");
            PopulateListView();
        }
        

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged_ItemCode(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = SparePartDB.parts.Where(p => p.ItemCode.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            sparePartDataGrid.ItemsSource = filteredList;
        }

        private void TextBox_TextChanged_Description(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = SparePartDB.parts.Where(p => p.Description.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            sparePartDataGrid.ItemsSource = filteredList;
        }

        private void TextBox_TextChanged_Type(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = SparePartDB.parts.Where(p => p.Type.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            sparePartDataGrid.ItemsSource = filteredList;
        }

        private void TextBox_TextChanged_Price(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = SparePartDB.parts.Where(p => p.FCAPrice.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            sparePartDataGrid.ItemsSource = filteredList;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            SparePart selectedSparePart = (SparePart)sparePartDataGrid.SelectedItem;

            if (selectedSparePart != null)
            {
                PartDetailWindow partDetailWindow = new PartDetailWindow(selectedSparePart);
                partDetailWindow.ShowDialog();
                PopulateListView();
            }           
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            PopulateListView();
        }
    }
}
