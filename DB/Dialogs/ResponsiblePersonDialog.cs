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
    public partial class ResponsiblePersonDialog : Dialog
    {
        private readonly Organization _organization;

        public ResponsiblePersonDialog(DialogState dialogState, Organization organization, 
            long? responsiblePersonId = null) : base(dialogState, responsiblePersonId)
        {
            _organization = organization;
            InitializeComponentAndSetDialogButtons();
        }

        protected override void InitializeComponentAndSetDialogButtons()
        {
            InitializeComponent();
            organizationLabel.Text = _organization.Name;
            SetDialogButtons(okButton, cancelButton);
        }

        protected override void SetTextboxesValues()
        {
            var responsiblePerson = EntityManager.GetResponsiblePerson(Id.Value);
            var organization = EntityManager.GetOrganization(responsiblePerson.OrganizationId);

            numberProxyTextBox.Text = responsiblePerson.ProxyId.ToString();
            organizationLabel.Text = organization.Name;
            lastnameTextBox.Text = responsiblePerson.Lastname;
            nameTextBox.Text = responsiblePerson.Name;
            patronymicTextBox.Text = responsiblePerson.Patronymic;
            postTextBox.Text = responsiblePerson.Post;
            proxyReceivedDatePicker.Value = responsiblePerson.ProxyReceivedDate;
            proxyExpiredDatePicker.Value = responsiblePerson.ProxyExpiredDate;
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            var responsiblePerson = new ResponsiblePerson()
            {
                OrganizationId = _organization.OrganizationId,
                ProxyId = long.Parse(numberProxyTextBox.Text),
                Lastname = lastnameTextBox.Text,
                Name = nameTextBox.Text,
                Patronymic = patronymicTextBox.Text,
                Post = postTextBox.Text,
                ProxyReceivedDate = proxyReceivedDatePicker.Value,
                ProxyExpiredDate = proxyExpiredDatePicker.Value
            };
            if (DialogState == DialogState.Add)
            {
                EntityManager.InsertResponsiblePerson(responsiblePerson);
            }
            else if (DialogState == DialogState.Edit)
            {
                EntityManager.UpdateResponsiblePerson(Id.Value, responsiblePerson);
            }
            this.Close();
        }
    }
}
