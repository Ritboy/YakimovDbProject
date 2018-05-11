using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.Dialogs
{
    public partial class OpenBillDialog : Form
    {
        private readonly Bill _bill;

        public OpenBillDialog()
        {
            InitializeComponent();
        }

        public OpenBillDialog(int billId) : this()
        {
            _bill = EntityManager.GetBill(billId);
        }

        private void OpenBillDialog_Load(object sender, EventArgs e)
        {
            productsTable.DataSource = _bill.GetProducts();

            billNumberLabel.Text = _bill.BillId.ToString();
            amountLabel.Text = _bill.Amount.ToString();
            discountLabel.Text = _bill.Discount.ToString();
        }

        private void discountNumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void discountCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void amountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
