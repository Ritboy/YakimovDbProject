using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class BillProduct
    {
        public long BillId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Nds { get; set; }
        public double Sum { get; set; }
    }
}
