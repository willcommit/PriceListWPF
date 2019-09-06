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

        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    NewPartsWindow newPartsWindow = new NewPartsWindow();
        //    newPartsWindow.ShowDialog();
        //    PopulateListView();
        //}

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
        
        private void MenuItemImportProtectedExcel_Click(object sender, RoutedEventArgs e)
        {
            Xlxs xlxs = new Xlxs();
            xlxs.setFileName();
            var package = xlxs.readExcel("fsa123a");

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

    }
}
