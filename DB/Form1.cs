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

        public Form1()
        {
            InitializeComponent();

            supplyTable.AutoGenerateColumns = false;
            organizationsTable.AutoGenerateColumns = false;
            productTable.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(ConfigurationManager.ConnectionStrings["DatabasePath"].ConnectionString))
            {
                EntityManager.CreateTables();
            }

            updateAllTables();
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
            updateProductTable();
        }

        private void removeSupplyButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(supplyTable);
            EntityManager.DeleteSupply(id);
            updateProductTable();
        }

        private void supplyTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                switch (grid.Columns[e.ColumnIndex].DataPropertyName)
                {
                    case "Bill":
                        var openBillDialog = new OpenBillDialog(Convert.ToInt32(grid.SelectedCells[0].Value));
                        openBillDialog.ShowDialog(this);
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
            var addProductDialog = new AddNewProduct(DialogState.Add);
            addProductDialog.ShowDialog(this);
            updateProductTable();
        }

        private void openProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            var addProductDialog = new AddNewProduct(DialogState.Open, id);
            addProductDialog.ShowDialog(this);
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            var addProductDialog = new AddNewProduct(DialogState.Edit, id);
            addProductDialog.ShowDialog(this);
            updateProductTable();
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(productTable);
            EntityManager.DeleteProduct(id);
            updateProductTable();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
