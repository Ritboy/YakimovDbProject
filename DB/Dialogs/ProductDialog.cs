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
    public partial class ProductDialog : Dialog
    {
        public ProductDialog(DialogState state, long? id = null) : base(state, id)
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
            var product = EntityManager.GetProduct(Id.Value);

            nameTextBox.Text = product.Name;
            tuTextBox.Text = product.Tu;
            measureTextBox.Text = product.Measure;
            availableNumeric.Value = product.Available;
            availableLable.Text = product.Available.ToString();
            priceNumeric.Value = (decimal)product.Price;
            priceLabel.Text = product.Price.ToString();
            descriptionRichTextBox.Text = product.Description;
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            var product = new Product()
            {
                Name = nameTextBox.Text,
                Tu = tuTextBox.Text,
                Available = (int)availableNumeric.Value,
                Measure = measureTextBox.Text,
                Price = (int)priceNumeric.Value,
                Description = descriptionRichTextBox.Text
            };

            if (DialogState == DialogState.Add)
            {
                EntityManager.InsertProduct(product);
            }
            else if (DialogState == DialogState.Edit)
            {
                EntityManager.UpdateProduct(Id.Value, product);
            }
            this.Close();
        }
    }
}
