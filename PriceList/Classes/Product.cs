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
        public int DiscountDealer { get; set; }
        public int DiscountMyndighet { get; set; }
        public int Quantity { get; set; }
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
            set { priceTotal = UnitPrice * Quantity; }
        }

        private int pricePerUnit;

        public int PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = UnitPrice * Quantity; }
        }

        public Product()
        {
            Description = " ";
            VendorItemNo = " ";
            Markup = 0;
            Quantity = 0;
            Customs = 0;
            Selected = false;
        }
    }
}
