using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    class SparePartDB
    {
        public string databasePath { get; set; }

        public void SetDatabasePath()
        {
            string databaseName = "SpareParts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            databasePath = System.IO.Path.Combine(folderPath, databaseName);
        }

        public void SetDatabasePath(string path)
        {
            databasePath = path;
        }

        public void InsertData (SparePart part)
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<SparePart>();
                connection.Insert(part);
            } 
        }

        public void InsertDataFast(List<SparePart> parts)
        {

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
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
