using System;
using System.Windows.Forms;
using Domain;

namespace ClientForm
{
    public partial class AddService : Form
    {
        private readonly UiController.UIController _uiController;
        private readonly bool _isEdit;
        private Service _service;

        public AddService(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
            _isEdit = false;
        }
        public AddService(UiController.UIController uiController, DataGridView dgvServices)
        {
            InitializeComponent();
            _uiController = uiController;
            _isEdit = true;
            _service = UiController.UIController.PopulateServiceDetails(dgvServices, txtName, txtPrice, txtDescription, btnSave, btnCancel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = _isEdit 
                ? _uiController.UpdateService(_service.Id, txtName, txtPrice, txtDescription)
                : _uiController.AddService( txtName, txtPrice, txtDescription);
            if (result == 1) { Dispose(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AddService_Load(object sender, EventArgs e)
        {

        }
    }
}
