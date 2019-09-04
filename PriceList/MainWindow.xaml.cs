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

        private void ImportExcel_Click(object sender, RoutedEventArgs e)
        {
            Xlxs xlxs = new Xlxs();
            xlxs.Pwd = "fsa123a";
            xlxs.setFileName();
            xlxs.ReadXlxsToDb();
            MessageBox.Show("COMPLETE!");
            PopulateListView();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NewPartsWindow newPartsWindow = new NewPartsWindow();
            newPartsWindow.ShowDialog();
            PopulateListView();
        }

        public void PopulateListView()
        {
            SparePartDB.ReadDatabase();

            try
            {
                if (SparePartDB.parts != null)
                {
                    sparePartListView.ItemsSource = SparePartDB.parts;
                    listSizeLabel.Content = sparePartListView.Items.Count;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
