﻿using PriceList.Model;
using PriceList.ViewModel.Helpers;
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
            ProductDB.SetDatabasePath();
            PopulateListView();
        }

        public void PopulateListView()
        {
            ProductDB.ReadDatabase();

            try
            {
                if (ProductDB.products != null)
                {
                    productDataGrid.ItemsSource = ProductDB.products;
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

            ProductDB.products.Clear();

            xlxs.populatePartsList(package, ProductDB.products);
 
            ProductDB.PopulateDataBase();
            PopulateListView();
        }
        

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged_ItemNo(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = ProductDB.products.Where(p => p.ItemNo.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            productDataGrid.ItemsSource = filteredList;
        }

        private void TextBox_TextChanged_Model(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = ProductDB.products.Where(p => p.Model.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            productDataGrid.ItemsSource = filteredList;
        }

        private void TextBox_TextChanged_Description(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = ProductDB.products.Where(p => p.Description.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            productDataGrid.ItemsSource = filteredList;
        }

        private void Row_RightClick(object sender, MouseButtonEventArgs e)
        {
            Product selectedProduct = (Product)productDataGrid.SelectedItem;

            if (selectedProduct != null)
            {
                ProductDetailWindow productDetailWindow = new ProductDetailWindow(selectedProduct);
                productDetailWindow.ShowDialog();
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
