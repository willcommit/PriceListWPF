using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    public class Product
    {
        [PrimaryKey]
        public string ItemNo { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string VendorItemNo { get; set; }

        public int UnitCost { get; set; }
        public int Markup { get; set; }
        public int Discount { get; set; }
        public int Amount { get; set; }
        public int Customs { get; set; }
        public bool Selected { get; set; }


        private int unitPrice;

        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        private int priceTotal;

        public int PriceTotal
        {
            get { return priceTotal; }
            set { priceTotal = UnitPrice * Amount; }
        }

        private int pricePerUnit;

        public int PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = UnitPrice * Amount; }
        }


        public Product()
        {
            Amount = 0;
            Selected = false;
        }
    }
}
