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
    public partial class ManageUsers : BaseForm
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void updateTable()
        {
            UpdateTable(grid, EntityManager.GetUsersTable());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var userDialog = new UserDialog(DialogState.Add);
            userDialog.ShowDialog();
            updateTable();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var selectedId = GetSelectedIdFromTable(grid);
            var userDialog = new UserDialog(DialogState.Edit, selectedId);
            userDialog.ShowDialog();
            updateTable();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var id = GetSelectedIdFromTable(grid);
            EntityManager.DeleteUser(id);
            updateTable();
        }
    }
}
