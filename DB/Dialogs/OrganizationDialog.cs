using DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.Dialogs
{
    public partial class OrganizationDialog : Dialog
    {
        private const string _addDialogText = "Новая организация";

        public OrganizationDialog(DialogState dialogState, long? inn = null) : base(dialogState, inn)
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
            var organization = EntityManager.GetOrganization(Id.Value);

            nameTextBox.Text = organization.Name;
            addressTextBox.Text = organization.Address;
            emailTextBox.Text = organization.Email;
            phoneTextBox.Text = organization.Phone;
            postAddressTextBox.Text = organization.PostAddress;
            postIndexTextBox.Text = organization.PostIndex.ToString();
            okpoTextBox.Text = organization.Okpo.ToString();
            bikTextBox.Text = organization.Bik.ToString();
            correspondentAccountTextBox.Text = organization.CorrespondentAccount.ToString();
            settlementAccountTextBox.Text = organization.SettlementAccount.ToString();
            ogrnTextBox.Text = organization.Ogrn.ToString();
            innTextBox.Text = organization.Inn.ToString();
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(textBox => textBox.Text == ""))
            {
                MessageBox.Show("Необходимо заполнить все поля", "Система учёта поставок КСИ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var newOrganization = new Organization()
            {
                Name = nameTextBox.Text,
                Address = addressTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
                PostAddress = postAddressTextBox.Text,
                PostIndex = long.Parse(postIndexTextBox.Text),
                Okpo = long.Parse(okpoTextBox.Text),
                Bik = long.Parse(bikTextBox.Text),
                CorrespondentAccount = correspondentAccountTextBox.Text,
                SettlementAccount = settlementAccountTextBox.Text,
                Ogrn = long.Parse(ogrnTextBox.Text),
                Inn = long.Parse(innTextBox.Text)
            };
            if (DialogState == DialogState.Add)
            {
                EntityManager.InsertOrganization(newOrganization);
            }
            else if (DialogState == DialogState.Edit)
            {
                EntityManager.UpdateOrganization(Id.Value, newOrganization);
            }
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void postIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(postIndexTextBox.Text, "[^0-9]"))
            {
                postIndexTextBox.Text = postIndexTextBox.Text.Remove(postIndexTextBox.Text.Length - 1);
            }
        }

        private void innTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(innTextBox.Text, "[^0-9]"))
            {
                innTextBox.Text = innTextBox.Text.Remove(innTextBox.Text.Length - 1);
            }
        }

        private void bikTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(bikTextBox.Text, "[^0-9]"))
            {
                bikTextBox.Text = postIndexTextBox.Text.Remove(bikTextBox.Text.Length - 1);
            }
        }

        private void correspondentAccountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(correspondentAccountTextBox.Text, "[^0-9]"))
            {
                correspondentAccountTextBox.Text = correspondentAccountTextBox.Text.Remove(correspondentAccountTextBox.Text.Length - 1);
            }
        }

        private void settlementAccountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(settlementAccountTextBox.Text, "[^0-9]"))
            {
                settlementAccountTextBox.Text = settlementAccountTextBox.Text.Remove(settlementAccountTextBox.Text.Length - 1);
            }
        }

        private void okpoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(okpoTextBox.Text, "[^0-9]"))
            {
                okpoTextBox.Text = okpoTextBox.Text.Remove(okpoTextBox.Text.Length - 1);
            }
        }

        private void ogrnTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(ogrnTextBox.Text, "[^0-9]"))
            {
                ogrnTextBox.Text = ogrnTextBox.Text.Remove(ogrnTextBox.Text.Length - 1);
            }
        }
    }

    public enum DialogState
    {
        Add,
        Open,
        Edit
    }
}
