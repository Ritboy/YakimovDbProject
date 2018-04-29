using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DB.Entities
{
    public class Organization
    {
        public long OrganizationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } //TODO: Прикрутить регулярки в инпутах
        public string Phone { get; set; }
        public long Inn { get; set; }
        public string PostAddress { get; set; }
        public long PostIndex { get; set; }
        public long Okpo { get; set; }
        public long Bik { get; set; }
        public string CorrespondentAccount { get; set; }
        public string SettlementAccount { get; set; }
        public long Ogrn { get; set; }

        public Organization() {}

        public Organization(int organizationId, string name, string address, string email, string phone)
        {
            OrganizationId = organizationId;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
