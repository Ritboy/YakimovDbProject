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
    public partial class SelectResponsiblePersonsDialog : BaseForm
    {
        private readonly Organization _organization;

        public ResponsiblePerson SelectedResponsiblePerson { get; set; }

        public SelectResponsiblePersonsDialog(long organizationId)
        {
            _organization = EntityManager.GetOrganization(organizationId);
            InitializeComponent();
            organizationLabel.Text = _organization.Name;
        }

        public SelectResponsiblePersonsDialog(Organization organization)
        {
            _organization = organization;
            InitializeComponent();
            organizationLabel.Text = _organization.Name;
        }

        private void updateTable()
        {
            UpdateTable(grid, EntityManager.GetResponsiblePersonTableByOrganizationId(_organization.OrganizationId));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var responsiblePersonDialog = new ResponsiblePersonDialog(DialogState.Add, _organization);
            responsiblePersonDialog.ShowDialog();
            updateTable();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(grid))
            {
                var responsiblePersonDialog = new ResponsiblePersonDialog(DialogState.Edit, _organization, GetSelectedIdFromTable(grid));
                responsiblePersonDialog.ShowDialog();
                updateTable();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(grid))
            {
                EntityManager.DeleteResponsiblePerson(GetSelectedIdFromTable(grid));
                updateTable();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (CheckSelectedRow(grid))
            {
                var responsiblePersonDialog = new ResponsiblePersonDialog(DialogState.Open, _organization, GetSelectedIdFromTable(grid));
                responsiblePersonDialog.ShowDialog();
                updateTable();
            }
        }

        private void SelectResponsiblePersonsDialog_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(grid);
            SelectedResponsiblePerson = EntityManager.GetResponsiblePerson(id);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var lastname = lastNameTextBox.Text;
            var proxy = proxyTextBox.Text;

            UpdateTable(grid, EntityManager.GetResponsiblePersonFilteredTableByOrganizationId(_organization.OrganizationId, lastname, proxy));
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lastNameTextBox.Text = "";
            proxyTextBox.Text = "";

            updateTable();
        }

        private void organizationLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new OrganizationDialog(DialogState.Open, _organization.OrganizationId).ShowDialog();
        }
    }
}
