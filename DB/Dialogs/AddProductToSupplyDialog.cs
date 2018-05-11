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
    public partial class AddProductToSupplyDialog : BaseForm
    {
        public BillProduct BillProduct { get; set; }

        public AddProductToSupplyDialog()
        {
            InitializeComponent();
        }

        private void AddProductToSupplyDialog_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void updateTable()
        {
            UpdateTable(productTable, EntityManager.GetProductsMainTable());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            BillProduct = new BillProduct()
            {
                ProductId = GetSelectedIdFromTable(productTable),
                Quantity = (int)quantityNumeric.Value,
                Price = (double)priceNumeric.Value,
                Nds = (int)ndsNumeric.Value
            };
            BillProduct.Sum = BillProduct.Price * BillProduct.Quantity;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
