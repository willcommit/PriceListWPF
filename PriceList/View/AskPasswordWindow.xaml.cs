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
    /// Interaction logic for AskPasswordWindow.xaml
    /// </summary>
    public partial class AskPasswordWindow : Window
    {
        public string pwd { get; set; } //safe?
        public AskPasswordWindow()
        {
            InitializeComponent();
        }

        private void okPwd_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
