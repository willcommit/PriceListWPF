using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceList.ViewModel.Helpers;
using PriceList.Model;
using PriceList.ViewModel.Commands;

namespace PriceList.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {

        // Se bokmärkt artikel om filtrering "as you type" MVVM i FireFox
        private string filter;

        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnPropertyChanged("Query");
            }
        }

        private Product product;

        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public MainVM()
        {
            SearchCommand = new SearchCommand(this);
        }

        public void MakeQueryItemNo ()
        {
            
            var filteredList = ProductDB.products.Where(p => p.ItemNo.ToLower().Contains(Filter.ToLower())).ToList();
            //productDataGrid.ItemsSource = filteredList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
