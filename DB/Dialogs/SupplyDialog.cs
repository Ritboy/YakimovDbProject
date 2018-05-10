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
using DB.Entities;

namespace DB.Dialogs
{
    public partial class SupplyDialog : Dialog
    {
        private Supply _supply;

        public Organization Organization { get; set; }
        public ResponsiblePerson ResponsiblePerson { get; set; }
        public Bill Bill { get; set; }
        public List<BillProduct> BillProduct { get; set; } = new List<BillProduct>();

        public SupplyDialog()
        {
            InitializeComponent();
        }

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
            //var supply = EntityManager.GetSupply(Id.Value);
            //var organization = supply.GetOrganization();
            //var responsiblePerson = supply.GetResponsiblePerson();
            //var bill = supply.GetBill();

            organizationLinkLabel.Text = Organization.Name;
            preparationDatePicker.Value = _supply.Preparation_date;
            expirationDatePicker.Value = _supply.Expiration_date;
            statusComboBox.SelectedIndex = (int)_supply.Status;
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
            }

            else if (statusComboBox.SelectedIndex == 3 && ResponsiblePerson == null)
            {
                MessageBox.Show(this, "Если поставка завершена, необходимо указать, ответсвенное лицо, которое приняло поставку. Укажите ответсвенное лицо или измените статус поставки", "Ответсвенное лицо не указано", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                _supply = new Supply()
                {
                    OrganizationId = Organization.OrganizationId,
                    ResponsiblePersonId = ResponsiblePerson?.ResponsiblePersonId,
                    BillId = Bill.BillId,
                    Preparation_date = preparationDatePicker.Value,
                    Expiration_date = expirationDatePicker.Value,
                    Execution_date = executionDatePicker.Value,
                    Status = (SupplyStatus)statusComboBox.SelectedIndex
                };

                Bill.Amount = double.Parse(amountLabel.Text);
                Bill.Discount = discountCheckBox.Checked ? (int)discountNumeric.Value : 0;

                if (DialogState == DialogState.Add)
                {
                    EntityManager.InsertSupply(_supply);
                    EntityManager.InsertBill(Bill);
                    BillProduct.ForEach(billProduct => EntityManager.InsertBillProduct(billProduct));
                }
                else if (DialogState == DialogState.Edit)
                {
                    EntityManager.UpdateSupply(_supply.SupplyId, _supply);
                    EntityManager.UpdateBill(Bill.BillId, Bill);
                    BillProduct.ForEach(billProduct => EntityManager.UpdateBillProduct(billProduct.BillId, billProduct.ProductId, billProduct));
                }
                this.Close();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //var bill = new Bill()
            //{
            //    BillId = EntityManager.Get
            //    SupplyId = EntityManager.GetNextSupplyId(),
            //    Amount = double.Parse(amountLabel.Text),
            //    Discount = (int)discountNumeric.Value
            //};

            //var supply = new Supply()
            //{
            //    OrganizationId = Organization.OrganizationId,
            //    BillId = Bill.BillId,
            //    ResponsiblePersonId = ResponsiblePerson.ResponsiblePersonId,
            //    Preparation_date = preparationDatePicker.Value,
            //    Expiration_date = expirationDatePicker.Value,
            //    Execution_date = executionDatePicker.Value,
            //    Status = (SupplyStatus)statusComboBox.SelectedIndex
            //};

            //var Bill = new Bill()
            //{

            //}
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void changeOrganizationButton_Click(object sender, EventArgs e)
        {
            var organizationDialog = new SelectOrganizationDialog();
            organizationDialog.ShowDialog(this);
            if (organizationDialog.SelectedId != null)
            {
                Organization = EntityManager.GetOrganization(organizationDialog.SelectedId.Value);
                organizationLinkLabel.Text = Organization.Name;
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProductToSupplyDialog = new AddProductToSupplyDialog();
            addProductToSupplyDialog.ShowDialog();
            if (BillProduct.Any(product => product.ProductId ==  addProductToSupplyDialog.BillProduct.ProductId))
            {
                MessageBox.Show("В этом счёте уже добавлена такая продукция. " +
                                "Вы можете изменить количество, цену или ндс в таблице", "Продукция уже добавлена", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                addProductToTable(addProductToSupplyDialog);
                var billProduct = addProductToSupplyDialog.BillProduct;
                billProduct.BillId = Bill.BillId;
                BillProduct.Add(billProduct);
            }
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productsTable);
            BillProduct.Remove(BillProduct.First(billProduct => billProduct.BillId == id));
            productsTable.Rows.Remove(productsTable.SelectedRows[0]);
            updateTable();
        }

        private void updateTable()
        {
            
        }

        private void addProductToTable(AddProductToSupplyDialog dialog)
        {
            var billProduct = dialog.BillProduct;
            if (billProduct != null)
            {
                var product = EntityManager.GetProduct(billProduct.ProductId);
                productsTable.Rows.Add(product.Id, product.Tu, product.Measure, product.Name, billProduct.Quantity, billProduct.Price, billProduct.Nds, billProduct.Sum);
                amountLabel.Text = (double.Parse(amountLabel.Text) + billProduct.Sum).ToString();
            }
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplyResolvedPanel.Enabled = statusComboBox.SelectedIndex == 3;
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
            }
        }

        private void changeResponsiblePersonButton_Click(object sender, EventArgs e)
        {

        }
    }
}
