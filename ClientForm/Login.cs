using UiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Login : Form
    {
        private readonly UiController.UIController _uiController;

        public Login(UiController.UIController uiController)
        {
            _uiController = uiController;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.CharacterCasing = CharacterCasing.Lower;
            Font font = new Font("Times New Roman", 12.0f,
                        FontStyle.Bold);
            txtPassword.Font = font;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result = _uiController.Login(txtUsername, txtPassword);
            if (result == 1) {
                Dispose();
            }
        }
    }
}
