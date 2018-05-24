using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using DB.Entities;
using System.Data.SQLite;
using DB.Dialogs;
using System.IO;

namespace DB
{
    public partial class Form1 : BaseForm
    {
        private SQLiteConnection _connection;
        //private SQLiteDataAdapter _dataAdapter;
        private DataTable dataTable;

        private readonly User _user;
        private readonly string _login;
        private readonly long _userId;

        public bool DoRelogin { get; private set; } = false;

        public Form1(string login)
        {
            InitializeComponent();

            supplyTable.AutoGenerateColumns = false;
            organizationsTable.AutoGenerateColumns = false;
            productTable.AutoGenerateColumns = false;

            _login = login;
            _userId = EntityManager.GetUserId(_login);
            _user = EntityManager.GetUser(_userId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(ConfigurationManager.ConnectionStrings["DatabasePath"].ConnectionString))
            {
                EntityManager.CreateTables();
            }

            updateAllTables();
            userNameLabel.Text = _user.Login;
            if (!_user.IsAdmin)
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
            if (!_user.IsEditable)
            {
                organizationEditableButtonsPanel.Visible = false;
                productEditableButtonsPanel.Visible = false;
                supplyEditableButtonsPanel.Visible = false;
            }
        }

        private void updateAllTables()
        {
            updateSuppliesTable();
            updateOrganizationTable();
            updateProductTable();
        }

        private void updateSuppliesTable()
        {
            UpdateTable(supplyTable, EntityManager.GetSuppliesMainTable());
        }

        private void updateOrganizationTable()
        {
            organizationsTable.DataSource = EntityManager.GetOrganizationsMainTable();
        }

        private void updateProductTable()
        {
            productTable.DataSource = EntityManager.GetProductsMainTable();
        }

        #region Handlers

        //Supply tab

        private void addSupplyButton_Click(object sender, EventArgs e)
        {
            new SupplyDialog(DialogState.Add).ShowDialog(this);
            updateSuppliesTable();
        }

        private void openSupplyButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(supplyTable);
            var supplyDialog = new SupplyDialog(DialogState.Open, id);
            supplyDialog.ShowDialog(this);
        }

        private void editSupplyButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(supplyTable);
            var supplyDialog = new SupplyDialog(DialogState.Edit, id);
            supplyDialog.ShowDialog(this);
            updateSuppliesTable();
        }

        private void removeSupplyButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(supplyTable);
            EntityManager.DeleteSupply(id);
            EntityManager.DeleteBill(id);
            EntityManager.DeleteBillProductWholeBill(id);
            updateSuppliesTable();
        }

        private void supplyTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                var supplyId = GetSelectedIdFromTable(supplyTable);
                var supply = EntityManager.GetSupply(supplyId);
                switch (grid.Columns[e.ColumnIndex].DataPropertyName)
                {
                    case "Bill":
                        var openBillDialog = new OpenBillDialog((int)supply.BillId);
                        openBillDialog.ShowDialog(this);
                        break;
                    case "OrganizationName":
                        var organizationDialog = new OrganizationDialog(DialogState.Open, supply.OrganizationId);
                        organizationDialog.ShowDialog(this);
                        break;
                }
            }
        }

        //Organizations tab
        private void addOrganizationButton_Click(object sender, EventArgs e)
        {
            new OrganizationDialog(DialogState.Add).ShowDialog(this);
            updateOrganizationTable();
        }

        #endregion

        private void openOrganizationButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var id = GetSelectedIdFromTable(organizationsTable);
                new OrganizationDialog(DialogState.Open, id).ShowDialog(this);
            }
        }

        private void editOrganizationButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var id = GetSelectedIdFromTable(organizationsTable);
                new OrganizationDialog(DialogState.Edit, id).ShowDialog(this);
                updateOrganizationTable();
            }
        }

        private void removeOrganizationButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var inn = GetSelectedIdFromTable(organizationsTable);
                EntityManager.DeleteOrganization(inn);
                updateOrganizationTable();
            }
        }

        //Product tab
        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProductDialog = new ProductDialog(DialogState.Add);
            addProductDialog.ShowDialog(this);
            updateProductTable();
        }

        private void openProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            var addProductDialog = new ProductDialog(DialogState.Open, id);
            addProductDialog.ShowDialog(this);
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            var addProductDialog = new ProductDialog(DialogState.Edit, id);
            addProductDialog.ShowDialog(this);
            updateProductTable();
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            EntityManager.DeleteProduct(id);
            updateProductTable();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var fromDateTime = supplyFromSearchDateTime.Value;
            var tillDateTime = supplyTillSearchDateTime.Value;
            var productName = supplyProductionNameTextBox.Text;
            var organizationName = supplyOrganizationNameTextBox.Text;

            supplyTable.DataSource = EntityManager.GetFilteredSuppliesTable(fromDateTime, tillDateTime, productName, organizationName);
        }

        private void supplyClearButton_Click(object sender, EventArgs e)
        {
            supplyFromSearchDateTime.Value = DateTime.Today;
            supplyTillSearchDateTime.Value = DateTime.Today;
            supplyProductionNameTextBox.Text = "";
            supplyOrganizationNameTextBox.Text = "";

            updateSuppliesTable();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageUsers = new ManageUsers();
            manageUsers.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePasswordDialog(_userId).ShowDialog();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRelogin = true;
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердите выход из программы", "Система учета поставок КСИ - Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        private void organizationSearchButton_Click(object sender, EventArgs e)
        {
            var name = organizationNameTextBox.Text;
            var inn = organizationInnTextBox.Text;
            var account = organizationAccountTextBox.Text;

            UpdateTable(organizationsTable, EntityManager.GetFilteredOrganizationTable(name, inn, account));
        }

        private void organizationClearButton_Click(object sender, EventArgs e)
        {
            organizationNameTextBox.Text = "";
            organizationInnTextBox.Text = "";
            organizationAccountTextBox.Text = "";

            updateOrganizationTable();
        }

        private void productSearchButton_Click(object sender, EventArgs e)
        {
            var name = productNameTextBox.Text;
            var tu = productTuTextBox.Text;
            var availableFrom = (int)productAvailableFromNumeric.Value;
            var availableTill = (int)productAvailableTillNumeric.Value;

            UpdateTable(productTable, EntityManager.GetFilteredProductsTable(name, tu, availableFrom, availableTill));
        }

        private void productClearButton_Click(object sender, EventArgs e)
        {
            productNameTextBox.Text = "";
            productTuTextBox.Text = "";
            productAvailableFromNumeric.Value = 0;
            productAvailableTillNumeric.Value = 100;

            updateProductTable();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpDialog().ShowDialog();
        }
    }
}
