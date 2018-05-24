using DB.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login();
        }

        public static void Login()
        {
            var auth = new Auth();
            Application.Run(auth);
            if (auth.Passed)
            {
                var form = new Form1(auth.Login);
                Application.Run(form);
                if (form.DoRelogin)
                {
                    Login();
                }
            }
        }
    }
}
