using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PriceList.Classes
{
    static class SparePartDB
    {
        public static string databasePath { get; set; }
        public static List<SparePart> parts = new List<SparePart>();
        public static void SetDatabasePath()
        {
            string databaseName = "SpareParts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            databasePath = System.IO.Path.Combine(folderPath, databaseName);
        }

        public static void ReadDatabase()
        {
            using(SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                try
                {
                    parts = (connection.Table<SparePart>().ToList()).OrderBy(p => p.Type).ToList();                  
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ops..." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public static void InsertData (SparePart part)
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<SparePart>();
                connection.Insert(part);
                
            } 
        }

        public static void PopulateDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                //connection.DropTable<SparePart>();
                connection.CreateTable<SparePart>();
                connection.RunInTransaction(() =>
                {
                    foreach (var part in parts)
                    {
                        connection.InsertOrReplace(part);
                    }  
                });
            }   
        }
    }
}
