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
    public partial class AddOwner : Form
    {
        private readonly UiController.UIController _uiController;

        public AddOwner(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _uiController.AddOwner(txtFirstName, txtLastName, txtPhone, txtEmail);
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
