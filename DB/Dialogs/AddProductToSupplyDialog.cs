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
            productTable.SelectionChanged += productTable_SelectionChanged;
        }

        private void updateTable()
        {
            UpdateTable(productTable, EntityManager.GetProductsMainTable());
        }

        private Product getSelectedProduct()
        {
            var available = Convert.ToInt32(productTable.SelectedRows[0].Cells[3].Value);
            var price = Convert.ToDouble(productTable.SelectedRows[0].Cells[5].Value);
            return new Product()
            {
                Available = available,
                Price = price
            };
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

        private void priceListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            priceNumeric.Enabled = !priceListCheckBox.Checked;
            if (priceListCheckBox.Checked)
            {
                var price = Convert.ToDecimal(productTable.SelectedRows[0].Cells[5].Value);
                priceNumeric.Value = price;
            }
        }

        private void productTable_SelectionChanged(object sender, EventArgs e)
        {
            var product = getSelectedProduct();
            quantityNumeric.Maximum = product.Available;
            if (priceListCheckBox.Checked)
            {
                priceNumeric.Value = (decimal)product.Price;
            }
        }
    }
}
