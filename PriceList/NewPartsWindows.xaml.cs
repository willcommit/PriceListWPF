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
    public partial class NewPartsWindows : Window
    {
        public NewPartsWindows()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                //Name = nameTextBox.Text,
                //Email = emailTextBox.Text,
                //Phone = phoneNumberTextBox.Text
            };
            string databaseName = " ";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            Close();
        }
    }
}
