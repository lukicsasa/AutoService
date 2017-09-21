using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;

namespace ClientForm
{
    public partial class SearchServices : Form
    {
        private readonly UiController.UIController _uiController;

        public SearchServices(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCriteria.Text))
            {
                var services = _uiController.GetAllServices(null);
                dgvServices.DataSource = services;
            }
            else
            {
                _uiController.FindService(txtCriteria, dgvServices, null, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddService(_uiController, dgvServices).ShowDialog();
           _uiController.FindService(txtCriteria, dgvServices, null, false);
        }
    }
}
