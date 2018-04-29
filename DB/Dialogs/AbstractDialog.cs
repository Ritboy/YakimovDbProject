using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB.Dialogs
{
    public abstract class AbstractDialog : Form
    {
        protected readonly DialogState DialogState;
        protected readonly long? Id;
        protected Button OkButton;
        protected Button CancellButton;

        protected abstract void SetTextboxesValues();
        protected abstract void InitializeComponentAndSetDialogButtons();

        protected abstract void onOkButtonClick(object sender, EventArgs e);

        protected AbstractDialog() : base()
        {

        }

        protected AbstractDialog(DialogState dialogState, long? id) : base()
        {
            DialogState = dialogState;
            Id = id;
        }

        protected virtual void SetControlsReadOnly()
        {
            foreach (var control in this.Controls.Cast<Control>().Where(
                control => control is TextBoxBase || control is NumericUpDown || control is ComboBox || control is CheckBox))
            {
                if (control is TextBoxBase)
                {
                    var textBox = (control as TextBoxBase);
                    textBox.ReadOnly = true;
                    //textBox.BackColor = this.BackColor;
                    //textBox.BorderStyle = BorderStyle.None;
                    //textBox.Cursor = Cursors.Default;
                    //textBox.TabStop = false;
                }
                else
                {
                    control.Visible = false;
                }
            }
        }

        protected void SetDialogButtons(Button okButton, Button cancelButton)
        {
            OkButton = okButton;
            CancellButton = cancelButton;

            OkButton.Click += onOkButtonClick;
            switch (this.DialogState)
            {
                case DialogState.Add:
                    okButton.Text = "Добавить";
                    break;
                case DialogState.Open:
                    SetTextboxesValues();
                    SetControlsReadOnly();
                    OkButton.Visible = false;
                    CancellButton.Text = "Закрыть";
                    break;
                case DialogState.Edit:
                    SetTextboxesValues();
                    OkButton.Text = "Сохранить";
                    CancellButton.Text = "Отмена";
                    break;
            }
        }
    }
}
