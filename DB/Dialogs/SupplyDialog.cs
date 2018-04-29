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
                    BillId = EntityManager.GetNextBillId()
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
            responsiblePersonLinkLabel.Text = ResponsiblePerson.Lastname;
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
            _supply = new Supply()
            {
                OrganizationId = Organization.OrganizationId,
                ResponsiblePersonId = ResponsiblePerson.ResponsiblePersonId,
                BillId = Bill.BillId,
                Preparation_date = preparationDatePicker.Value,
                Expiration_date = expirationDatePicker.Value,
                Execution_date = executionDatePicker.Value,
                Status = (SupplyStatus)statusComboBox.SelectedIndex
            };

            Bill = new Bill()
            {
                Amount = double.Parse(amountLabel.Text),
                Discount = discountCheckBox.Checked ? (int)discountNumeric.Value : 0
            };

            if (DialogState == DialogState.Add)
            {
                EntityManager.InsertSupply(_supply);
                EntityManager.InsertBill(Bill);
            }
            else if (DialogState == DialogState.Edit)
            {
                EntityManager.UpdateSupply(_supply.SupplyId, _supply);
                EntityManager.UpdateBill(Bill.BillId, Bill);
            }
            this.Close();
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
            if (organizationDialog.SelectedInn != null)
            {
                organizationLinkLabel.Text = EntityManager.GetOrganization(organizationDialog.SelectedInn.Value).Name;
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProductToSupplyDialog = new AddProductToSupplyDialog();
            addProductToSupplyDialog.ShowDialog();
            if (addProductToSupplyDialog.SelectedProductId.HasValue)
            {
                addProductToTable(addProductToSupplyDialog);
            }
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {

        }

        private void addProductToTable(AddProductToSupplyDialog dialog)
        {
            var product = EntityManager.GetProduct(dialog.SelectedProductId.Value);
            var sum = dialog.Price * dialog.Quantity;
            productsTable.Rows.Add(product.Id, product.Name, dialog.Quantity, dialog.Price, 18, sum);
            amountLabel.Text = (double.Parse(amountLabel.Text) + sum).ToString();
        }
    }
}
