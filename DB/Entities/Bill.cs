using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Bill
    {
        public long BillId { get; set; }
        public long SupplyId { get; set; }
        public double Amount { get; set; }
        public int Discount { get; set; }

        public List<BillProduct> Products { get; set; } = new List<BillProduct>();

        public DataTable GetProducts()
        {
            return EntityManager.GetProductsTableFromBill(BillId);
        }
    }
}
