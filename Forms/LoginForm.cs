using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskFlow.Forms
{
    public class LoginForm : Form
    {
        private TextBox txtUserName;
        private Button btnLogin;

        public string UserName { get; private set; }

        public LoginForm()
        {
            Text = "Prisijungimas";
            Size = new Size(350, 200);
            StartPosition = FormStartPosition.CenterScreen;

            Label lblUserName = new Label
            {
                Text = "Įveskite vartotojo vardą:",
                Location = new Point(30, 30),
                AutoSize = true
            };

            txtUserName = new TextBox
            {
                Location = new Point(30, 60),
                Width = 260
            };

            btnLogin = new Button
            {
                Text = "Prisijungti",
                Location = new Point(30, 100),
                Width = 120
            };

            btnLogin.Click += BtnLogin_Click;

            Controls.Add(lblUserName);
            Controls.Add(txtUserName);
            Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Įveskite vartotojo vardą.");
                return;
            }

            UserName = txtUserName.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}