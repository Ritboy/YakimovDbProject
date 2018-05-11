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
    public partial class Auth : Form
    {
        public bool Passed { get; set; } = false;
        private int state;

        public Auth()
        {
            InitializeComponent();
            state = 0;
        }

        private void changeState()
        {
            if (state == 0)
            {
                groupBox.Text = "Вход в систему";
                submitButton.Text = "Вход";
                newUserButton.Text = "Новый пользователь";
            }
            else
            {
                groupBox.Text = "Новый пользователь";
                submitButton.Text = "Добавить";
                newUserButton.Text = "Отмена";
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
                //Passed = true;
                //Close();
            }
            if (state == 0)
            {
                if (!EntityManager.ValidateUser(loginTextBox.Text, passwordTextBox.Text))
                {
                    MessageBox.Show("Пользователя с таким логином и паролём не существует", "Неправильный логин или пароль", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    Passed = true;
                    this.Close();
                }
            }
            else
            {
                EntityManager.AddNewUser(loginTextBox.Text, passwordTextBox.Text);
                MessageBox.Show("Пользователь добавлен", "Новый пользователь успешно добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                changeState();
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            //if (state == 0)
            //{
            //    groupBox.Text = "Новый пользователь";
            //    submitButton.Text = "Добавить";
            //    newUserButton.Text = "Отмена";
            //    state = 1;
            //}
            //else
            //{
            //    groupBox.Text = "Вход в систему";
            //    submitButton.Text = "Вход";
            //    newUserButton.Text = "Новый пользователь";
            //    state = 0;
            //}

            Close();
        }
    }
}
