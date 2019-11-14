using PriceList.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PriceList.ViewModel.Helpers
{
    class ProductDB
    {
        public static string databasePath { get; set; }
        public static List<Product> products = new List<Product>();
        public static void SetDatabasePath()
        {
            string databaseName = "Pricelist.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            databasePath = System.IO.Path.Combine(folderPath, databaseName);
        }

        public static void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                try
                {
                    products = (connection.Table<Product>().ToList()).OrderBy(p => p.Model).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public static void InsertData(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Product>();
                connection.Insert(product);

            }
        }

        public static void PopulateDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                //connection.DropTable<SparePart>();
                connection.CreateTable<Product>();
                connection.RunInTransaction(() =>
                {
                    foreach (var product in products)
                    {
                        connection.InsertOrReplace(product);
                    }
                });
            }
        }
    }
}
