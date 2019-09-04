using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    class SparePart
    {
        [PrimaryKey]
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string FCAPrice{ get; set; }

        public override string ToString()
        {
            return $"{ItemCode} - {Description} - {Type} - {FCAPrice}";
        }
    }
}
