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
    public partial class UserDialog : Dialog
    {

        public UserDialog(DialogState dialogState, long? userId = null) : base(dialogState, userId)
        {
            InitializeComponentAndSetDialogButtons();
        }

        protected override void InitializeComponentAndSetDialogButtons()
        {
            InitializeComponent();
            SetDialogButtons(okButton, cancelButton);
        }

        protected override void SetTextboxesValues()
        {
            var user = EntityManager.GetUser(Id.Value);

            lastNameTextBox.Text = user.Lastname;
            nameTextBox.Text = user.Name;
            postTextBox.Text = user.Post;
            loginTextBox.Text = user.Login;
            passwordTextBox.Text = user.Password;
            repeatPasswordTextBox.Text = user.Password;
            isEditableCheckBox.Checked = user.IsEditable;
            isAdminCheckBox.Checked = user.IsAdmin;
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != repeatPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают. Проверьте правильность ввода", "Пароли не совпадают", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                var user = new User()
                {
                    Login = loginTextBox.Text,
                    Password = passwordTextBox.Text,
                    Lastname = lastNameTextBox.Text,
                    Name = nameTextBox.Text,
                    Post = postTextBox.Text,
                    IsEditable = isEditableCheckBox.Checked,
                    IsAdmin = isAdminCheckBox.Checked
                };
                if (DialogState == DialogState.Add)
                {
                    EntityManager.InsertUser(user);
                }
                if (DialogState == DialogState.Edit)
                {
                    EntityManager.UpdateUser(Id.Value, user);
                }
                this.Close();
            }
        }
    }
}
