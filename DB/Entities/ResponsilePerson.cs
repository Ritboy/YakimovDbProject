using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class ResponsiblePerson
    {
        public long ResponsiblePersonId { get; set; }
        public long OrganizationId { get; set; }
        public long ProxyId { get; set; }
        public string Post { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public Organization Organization { get; set; }
    }
}
