using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DB.Entities
{
    public class Supply
    {
        public long SupplyId { get; set; }
        public long OrganizationId { get; set; }
        public long BillId { get; set; }
        public long? ResponsiblePersonId { get; set; }
        public DateTime Preparation_date { get; set; }
        public DateTime Expiration_date { get; set; }
        public DateTime Execution_date { get; set; }
        public SupplyStatus Status { get; set; }

        public Organization Organization { get; set; }
        public Bill Bill { get; set; }
        public ResponsiblePerson ResponsilePerson { get; set; }

        public Supply()
        {

        }

        public Supply(int supplyId, int organizationId, DateTime prepDate, DateTime expDate)
        {
            SupplyId = supplyId;
            OrganizationId = organizationId;
            Preparation_date = prepDate;
            Expiration_date = expDate;
        }

        public Supply(object[] dataTableItemsRow) : this(
            Convert.ToInt32(dataTableItemsRow[4]), Convert.ToInt32(dataTableItemsRow[5]), 
            DateTime.Parse(dataTableItemsRow[6].ToString()), DateTime.Parse(dataTableItemsRow[7].ToString()))
        { }

        public Organization GetOrganization()
        {
            return EntityManager.GetOrganization(OrganizationId);
        }

        public ResponsiblePerson GetResponsiblePerson()
        {
            if (ResponsiblePersonId == null)
            {
                return null;
            }
            return EntityManager.GetResponsiblePerson(ResponsiblePersonId.Value);
        }

        public Bill GetBill()
        {
            return EntityManager.GetBill(BillId);
        }
    }

    public enum SupplyStatus
    {
        Open,
        PaymentReceived,
        ProductSent,
        ProductReceived,
        Close
    }
}
