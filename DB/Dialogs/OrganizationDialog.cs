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
    }

    public enum DialogState
    {
        Add,
        Open,
        Edit
    }
}
