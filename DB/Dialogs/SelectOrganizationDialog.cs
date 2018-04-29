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
    public partial class SelectOrganizationDialog : BaseForm
    {
        public long? SelectedInn { get; set; } = null;

        public SelectOrganizationDialog()
        {
            InitializeComponent();
        }

        private void SelectOrganizationDialog_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addOrganizationDialog = new OrganizationDialog(DialogState.Add);
            addOrganizationDialog.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var inn = GetSelectedIdFromTable(organizationsTable);
                var addOrganizationDialog = new OrganizationDialog(DialogState.Edit, inn);
                addOrganizationDialog.ShowDialog();
                updateTable();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var inn = GetSelectedIdFromTable(organizationsTable);
                var addOrganizationDialog = new OrganizationDialog(DialogState.Open, inn);
                addOrganizationDialog.ShowDialog();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(organizationsTable))
            {
                var inn = GetSelectedIdFromTable(organizationsTable);
                EntityManager.DeleteOrganization(inn);
                UpdateTable(organizationsTable, EntityManager.GetOrganizationsCompactTable());
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedInn = GetSelectedIdFromTable(organizationsTable);
            Close();
        }

        private void updateTable()
        {
            UpdateTable(organizationsTable, EntityManager.GetOrganizationsCompactTable());
        }
    }
}
