using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public class BaseForm : Form
    {
        public BaseForm() : base()
        {

        }

        protected void UpdateTable(DataGridView table, DataTable source)
        {
            table.DataSource = source;
        }

        protected bool CheckSelectedRow(DataGridView table)
        {
            if (table.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите строку с организацией",
                    "Организация не выбрана",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected long GetSelectedIdFromTable(DataGridView table)
        {
            return Convert.ToInt64(table.SelectedRows[0].Cells[0].Value.ToString());
        }

        protected void ValidateDigits(object sender, EventArgs e)
        {
            
        }
    }
}
