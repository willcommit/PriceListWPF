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
        }

        private void ImportExcel_Click(object sender, RoutedEventArgs e)
        {
            Xlxs xlxs = new Xlxs();
            xlxs.Pwd = "fsa123a";
            xlxs.setFileName();
            xlxs.ReadXlxsToDb();
            MessageBox.Show("COMPLETE!");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
