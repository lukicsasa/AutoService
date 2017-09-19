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
using Domain;

namespace ClientForm
{
    public partial class AddAuto : Form
    {
        private readonly UiController.UIController _uiController;
        private readonly bool _isEdit;
        private Auto auto;

        public AddAuto(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
            _isEdit = false;
            _uiController.GetAllOwners(cmbOwner);
            _uiController.GetAllAutoTypes(cmbAutoType);

        }

        public AddAuto(UiController.UIController uiController, DataGridView dgvResults, bool details)
        {
            InitializeComponent();
            _uiController = uiController;
            _isEdit = true;
            auto = _uiController.PopulateAutoUpdate(dgvResults, cmbOwner, cmbAutoType, txtProductionYear, txtGas, txtColor, txtDoors, txtRegNumber);

            if (!details) return;
            cmbOwner.Enabled = false;
            cmbAutoType.Enabled = false;
            txtProductionYear.Enabled = false;
            txtColor.Enabled = false;
            txtGas.Enabled = false;
            txtDoors.Enabled = false;
            txtRegNumber.Enabled = false;
            btnCancel.Visible = false;
            btnSubmit.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to quit?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (dr)
            {
                case DialogResult.Yes:
                    Dispose();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = _isEdit
                ? _uiController.UpdateAuto(auto.AutoId,txtRegNumber, txtColor, txtProductionYear, txtDoors, txtGas, cmbAutoType, cmbOwner)
                : _uiController.AddNewAuto(txtRegNumber, txtColor, txtProductionYear, txtDoors, txtGas, cmbAutoType, cmbOwner);
            if (result == 1) { Dispose(); }
        }
    }
}
