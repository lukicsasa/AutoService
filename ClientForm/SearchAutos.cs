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
    public partial class SearchAutos : Form
    {
        private readonly UiController.UIController _uiController;

        public SearchAutos(UiController.UIController uiController)
        {
            InitializeComponent();
            _uiController = uiController;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _uiController.FindAuto(txtCriteria, dgvAutos,true);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            new AddAuto(_uiController, dgvAutos,false).ShowDialog();
            _uiController.FindAuto(txtCriteria, dgvAutos, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _uiController.DeleteAuto(dgvAutos, txtCriteria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddAuto(_uiController, dgvAutos,true).ShowDialog();
            _uiController.FindAuto(txtCriteria, dgvAutos, false);
        }
    }
}
