using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tu { get; set; }
        public int Available { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
