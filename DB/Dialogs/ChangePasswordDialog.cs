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
    public partial class ChangePasswordDialog : Form
    {
        private readonly long _userId;

        public ChangePasswordDialog(long userId)
        {
            InitializeComponent();
            _userId = userId;
            DialogResult = DialogResult.None;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var oldPassword = oldPasswordTextBox.Text;
            var newPassword = newPasswordTextBox.Text;
            var repeatNewPassword = repeatNewPasswordTextBox.Text;
            var user = EntityManager.GetUser(_userId);

            if (oldPassword == user.Password && newPassword == repeatNewPassword)
            {
                user.Password = newPassword;
                EntityManager.UpdateUser(_userId, user);
                MessageBox.Show("Пароль успешно изменён", "Пароль изменён", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else if (oldPassword != user.Password)
            {
                MessageBox.Show("Действующий пароль введён неверно", "Неверный пароль", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (newPassword != repeatNewPassword)
            {
                MessageBox.Show("Введённые новые пароли не совпадают", "Пароли не совпадают", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
