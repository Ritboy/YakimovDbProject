using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public bool IsEditable { get; set; }
        public bool IsAdmin { get; set; }
    }
}
