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
    public partial class SupplyDialog : Dialog
    {
        private Supply _supply;

        public Organization Organization { get; set; }
        public ResponsiblePerson ResponsiblePerson { get; set; }
        public Bill Bill { get; set; }

        public SupplyDialog(DialogState dialogState, long? id = null) : base(dialogState, id)
        {
            if (id.HasValue)
            {
                _supply = EntityManager.GetSupply(id.Value);
                Organization = _supply.GetOrganization();
                ResponsiblePerson = _supply.GetResponsiblePerson();
                Bill = _supply.GetBill();
            }
            else
            {
                _supply = new Supply()
                {
                    SupplyId = EntityManager.GetNextSupplyId()
                };

                Bill = new Bill()
                {
                    BillId = EntityManager.GetNextBillId(),
                    SupplyId = _supply.SupplyId
                };
            }

            InitializeComponentAndSetDialogButtons();
        }

        protected override void InitializeComponentAndSetDialogButtons()
        {
            InitializeComponent();
            SetDialogButtons(okButton, cancelButton);
        }

        protected override void SetTextboxesValues()
        {
            organizationLinkLabel.Text = Organization.Name;
            preparationDatePicker.Value = _supply.Preparation_date;
            expirationDatePicker.Value = _supply.Expiration_date;
            statusComboBox.SelectedIndex = (int)_supply.Status;
            statusLabel.Text = statusComboBox.ValueMember;
            responsiblePersonLinkLabel.Text = ResponsiblePerson?.Lastname ?? "-";
            executionDatePicker.Value = _supply.Execution_date;
            billNumberLabel.Text = _supply.BillId.ToString();
            productsTable.DataSource = Bill.GetProducts();
            amountLabel.Text = Bill.Amount.ToString();
            discountNumeric.Value = Bill.Discount;
        }

        protected override void SetControlsReadOnly()
        {
            base.SetControlsReadOnly();
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            if (Organization == null)
            {
                MessageBox.Show("Выберите организацию получателя", "Организация не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            else if (statusComboBox.SelectedIndex == 3 && ResponsiblePerson == null)
            {
                MessageBox.Show(this, "Если поставка завершена, необходимо указать, ответсвенное лицо, которое приняло поставку. Укажите ответсвенное лицо или измените статус поставки", "Ответсвенное лицо не указано", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Bill.Amount = double.Parse(amountLabel.Text);
            Bill.Discount = discountCheckBox.Checked ? (int)discountNumeric.Value : 0;

            _supply.OrganizationId = Organization.OrganizationId;
            _supply.ResponsiblePersonId = ResponsiblePerson?.ResponsiblePersonId;
            _supply.BillId = Bill.BillId;
            _supply.Preparation_date = preparationDatePicker.Value;
            _supply.Expiration_date = expirationDatePicker.Value;
            _supply.Execution_date = executionDatePicker.Value;
            _supply.Status = (SupplyStatus)statusComboBox.SelectedIndex;

            if (DialogState == DialogState.Add)
            {
                EntityManager.InsertSupply(_supply);
                EntityManager.InsertBill(Bill);
                Bill.Products.ForEach(billProduct => EntityManager.InsertBillProduct(billProduct));
            }
            else if (DialogState == DialogState.Edit)
            {
                EntityManager.UpdateSupply(_supply.SupplyId, _supply);
                EntityManager.UpdateBill(Bill.BillId, Bill);
                Bill.Products.ForEach(billProduct => EntityManager.UpdateBillProduct(billProduct.BillId, billProduct.ProductId, billProduct));
            }
            this.Close();
        }

        private void applyDiscount()
        {
            var previousAmount = Bill.Amount;
            var discount = previousAmount * (double)discountNumeric.Value / 100;
            var amountWithDiscount = previousAmount - discount;
            amountLabel.Text = amountWithDiscount.ToString();
        }

        private void changeOrganizationButton_Click(object sender, EventArgs e)
        {
            var organizationDialog = new SelectOrganizationDialog();
            organizationDialog.ShowDialog(this);
            if (organizationDialog.SelectedId != null)
            {
                Organization = EntityManager.GetOrganization(organizationDialog.SelectedId.Value);
                organizationLinkLabel.Text = Organization.Name;
                responsiblePersonLinkLabel.Text = "Ответсвенное лицо";
                if (statusComboBox.SelectedIndex == 3)
                {
                    supplyResolvedPanel.Enabled = true;
                }
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProductToSupplyDialog = new AddProductToSupplyDialog();
            var result = addProductToSupplyDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Bill.Products.Any(product => product.ProductId == addProductToSupplyDialog.BillProduct.ProductId))
                {
                    MessageBox.Show("В этом счёте уже добавлена такая продукция. " +
                                    "Вы можете изменить количество, цену или ндс в таблице", "Продукция уже добавлена", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    var billProduct = addProductToSupplyDialog.BillProduct;
                    billProduct.BillId = Bill.BillId;
                    Bill.Products.Add(billProduct);
                    addProductToTable(addProductToSupplyDialog);
                }
            }
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productsTable);
            Bill.Products.RemoveAll(billProduct => billProduct.ProductId == id);
            productsTable.Rows.Remove(productsTable.SelectedRows[0]);
            updatePrices();
        }

        private void updatePrices()
        {
            Bill.Amount = Bill.Products.Sum<BillProduct>(product => product.Price * product.Quantity);
            amountLabel.Text = Bill.Amount.ToString();
        }

        private void addProductToTable(AddProductToSupplyDialog dialog)
        {
            var billProduct = dialog.BillProduct;
            if (billProduct != null)
            {
                var product = EntityManager.GetProduct(billProduct.ProductId);
                productsTable.Rows.Add(product.Id, product.Tu, product.Measure, product.Name, billProduct.Quantity, billProduct.Price, billProduct.Nds, billProduct.Sum);
            }
            updatePrices();
        }

        private void addProductToTable(BillProduct billProd)
        {
            var billProduct = billProd;
            if (billProduct != null)
            {
                var product = EntityManager.GetProduct(billProduct.ProductId);
                productsTable.Rows.Add(product.Id, product.Tu, product.Measure, product.Name, billProduct.Quantity, billProduct.Price, billProduct.Nds, billProduct.Sum);
            }
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplyResolvedPanel.Enabled = statusComboBox.SelectedIndex == 3 && Organization != null;
        }

        private void SupplyDialog_Load(object sender, EventArgs e)
        {
            statusComboBox.SelectedIndex = 0;
            if (DialogState == DialogState.Add)
            {
                billNumberLabel.Text = EntityManager.GetNextSupplyId().ToString();
            }
            if (DialogState == DialogState.Open)
            {
                changeOrganizationButton.Visible = false;
                changeResponsiblePersonButton.Visible = false;
                addProductButton.Visible = false;
                removeProductButton.Visible = false;
                okButton.Visible = false;
                discountCheckBox.Checked = false;
                discountCheckBox.Visible = false;
                discountNumeric.Value = 0;
                discountNumeric.Visible = false;
                discountLabel.Text = Bill.Discount.ToString();
            }

            updateTable();
        }

        private void changeResponsiblePersonButton_Click(object sender, EventArgs e)
        {
            var responsiblePersonDialog = new SelectResponsiblePersonsDialog(Organization);
            if (responsiblePersonDialog.ShowDialog(this) == DialogResult.OK)
            {
                ResponsiblePerson = responsiblePersonDialog.SelectedResponsiblePerson;
                responsiblePersonLinkLabel.Text = ResponsiblePerson.Lastname;
            }            
        }

        private void discountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            discountNumeric.Enabled = discountCheckBox.Checked;
            if (discountCheckBox.Enabled)
            {
                applyDiscount();
            }
            else
            {
                discountNumeric.Value = 0;
                applyDiscount();
            }
        }

        private void discountNumeric_ValueChanged(object sender, EventArgs e)
        {
            applyDiscount();
        }

        private void organizationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Organization != null)
            {
                new OrganizationDialog(DialogState.Open, Organization.OrganizationId).ShowDialog();
            }
        }

        private void responsiblePersonLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ResponsiblePerson != null)
            {
                new ResponsiblePersonDialog(DialogState.Open, Organization, ResponsiblePerson.ResponsiblePersonId)
                    .ShowDialog();
            }
        }

        private void updateTable()
        {
            productsTable.DataSource = Bill.Products;
        }
    }
}
