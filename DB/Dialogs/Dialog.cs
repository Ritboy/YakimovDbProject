using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Dialogs
{
    /// <summary>
    /// Just a class to easily resolve problem when Designer can't show form which inherit abstract class
    /// </summary>
    public class Dialog : AbstractDialog
    {
        protected Dialog()
        {

        }

        protected Dialog(DialogState dialogState, long? id) : base(dialogState, id)
        {
        }

        protected override void InitializeComponentAndSetDialogButtons()
        {
            throw new NotImplementedException();
        }

        protected override void onOkButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void SetTextboxesValues()
        {
            throw new NotImplementedException();
        }
    }
}
